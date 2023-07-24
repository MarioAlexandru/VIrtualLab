using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpMobile : MonoBehaviour
{
    public GameObject player;
    public GameObject playButton;
    public scenemanager scenemanager;
    public GameObject dropIcon;
    public GameObject grabIcon;
    public GameObject throwIcon;
    public Transform holdPos;
    public float throwForce = 500f;
    public float pickUpRange = 5f;
    private GameObject heldObj;
    private Rigidbody heldObjRb;
   
    private int LayerNumber;

    [SerializeField]
    private LayerMask layerMask;
    public bool canPickupMobile;
    public bool canDropMobile;
    public bool canRotateRightMobile;
    public bool canRotateLeftMobile;
    public bool canThrowMobile;
    public bool pickedUp = false;
    private FPSControler mouseLookScript;
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("HoldLayer");

        mouseLookScript = player.GetComponent<FPSControler>();
    }
    void Update()
    {
        RaycastHit hit;
        if (canPickupMobile)
        {
            if (heldObj == null) //if currently not holding anything
            {
                //perform raycast to check if player is looking at object within pickuprange
                
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    if (hit.transform.gameObject.tag == "canPickup")
                    {
                        //pass in object hit into the PickUpObject function

                        PickUpObject(hit.transform.gameObject);
                    }

                }
            }  
        }
        if (heldObj != null) //if player is holding object
        {
            MoveObject(); //keep object position at holdPos
            RotateObjectMobile();
            if (canThrowMobile)
            {
                StopClipping();
                //ThrowObject();
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange,layerMask))
                {
                    if (hit.transform.gameObject.tag == "placePos")
                    {
                        PlaceObject(hit.rigidbody.gameObject);
                    }
                }
            }
            if (canDropMobile)
            {
                StopClipping();
                DropObject();
            }
        }
    }
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            pickedUp = true;
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); //assign Rigidbody
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
            heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            
            dropIcon.SetActive(true);
            throwIcon.SetActive(true);
            grabIcon.SetActive(false);
            canDropMobile = false;
            canPickupMobile = false;
            canThrowMobile = false;
            if (heldObj.GetComponent<MinigameTracker>() != null) scenemanager.minigameName = heldObj.GetComponent<MinigameTracker>().minigameName;
            else
            {
                if(scenemanager.minigameName == null) playButton.SetActive(true);
            }
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
            if(heldObj.GetComponent<SimpleTooltip>()) heldObj.GetComponent<SimpleTooltip>().ShowTooltip();
        }
        if(heldObj != null)
        {
            heldObjRb.transform.localEulerAngles = new Vector3(0,0,0);
            heldObjRb.transform.localPosition = new Vector3(0, 0, 0);
            if (heldObj.GetComponent<SimpleTooltip>() != null) heldObj.GetComponent<SimpleTooltip>().ShowTooltip();
        }
    }
    void DropObject()
    {
        //re-enable collision with player
        if(heldObj != null)
        {
            pickedUp = false;
            playButton.SetActive(false);
            dropIcon.SetActive(false);
            throwIcon.SetActive (false);
            grabIcon.SetActive(true);
            canPickupMobile = false;
            canDropMobile = false;
            canThrowMobile = false;
            if (heldObj.GetComponent<MinigameTracker>() != null) scenemanager.minigameName = "";
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            heldObj.layer = 0; //object assigned back to default layer
            heldObjRb.isKinematic = false;
            heldObj.transform.parent = null; //unparent object
            heldObj = null; //undefine game object
        }
        
    }

    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldObj.transform.position = holdPos.transform.position;
    }

    void RotateObjectMobile()
    {
        if(canRotateRightMobile)
        {
             heldObj.transform.Rotate(0,0,-10);
        }
        else if(canRotateLeftMobile)
        {
            heldObj.transform.Rotate(0, 0, 10);
        }
    }
    void ThrowObject()
    {
        //same as drop function, but add force to object before undefining it
        pickedUp = false;
        if (heldObj.GetComponent<MinigameTracker>() != null) scenemanager.minigameName = "";
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
        throwIcon.SetActive(false);
        dropIcon.SetActive(false);
        grabIcon.SetActive(true);
        playButton.SetActive(false);
        canPickupMobile = false;
        canDropMobile = false;
        canThrowMobile = false;
    }

    void PlaceObject(GameObject placePosition)
    {
        pickedUp = false;
        if (heldObj.GetComponent<MinigameTracker>() != null) scenemanager.minigameName = "";
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        //heldObj.transform.parent = placePosition.transform;
        heldObj.transform.parent = null;
        heldObj.transform.localPosition = new Vector3(-1.98f, 1.766f, -0.6849f);
        heldObj.transform.localEulerAngles = new Vector3(0, 5.94f, 0);
        heldObj = null;
        throwIcon.SetActive(false);
        dropIcon.SetActive(false);
        grabIcon.SetActive(true);
        playButton.SetActive(false);
        canPickupMobile = false;
        canDropMobile = false;
        canThrowMobile = false;
    }
    void StopClipping() //function only called when dropping/throwing
    {
        if(heldObj != null)
        {
            var clipRange = Vector3.Distance(heldObj.transform.position, transform.position);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
            if (hits.Length > 1)
            {
                heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
            }
        }
    }
}
