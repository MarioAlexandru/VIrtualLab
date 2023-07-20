using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUp : MonoBehaviour
{
    public GameObject player;
    public GameObject playButton;
    public scenemanager scenemanager;
    public GameObject dropIcon;
    public GameObject grabIcon;
    public Transform holdPos;
    public float throwForce = 500f;
    public float pickUpRange = 5f;
    private float rotationSensitivity = 2f;
    private GameObject heldObj;
    private Rigidbody heldObjRb;
    
    private bool canDrop = true;
    private int LayerNumber;

    private bool isMobileEnabled;
    public bool canPickupMobile;
    public bool canDropMobile;
    public bool canRotateRightMobile;
    public bool canRotateLeftMobile;
    public bool pickedUp = false;

    FPSControler mouseLookScript;
    void Start()
    {
        isMobileEnabled = player.GetComponent<FPSControler>().isMobileEnabled;
        LayerNumber = LayerMask.NameToLayer("HoldLayer");

        mouseLookScript = player.GetComponent<FPSControler>();
    }
    void Update()
    {
        if (!isMobileEnabled)
        {
            if (Input.GetKeyDown(KeyCode.E)) //change E to whichever key you want to press to pick up
            {
                if (heldObj == null) //if currently not holding anything
                {
                    //perform raycast to check if player is looking at object within pickuprange
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                    {
                        if (hit.transform.gameObject.tag == "canPickup")
                        {
                            //pass in object hit into the PickUpObject function

                            PickUpObject(hit.transform.gameObject);
                        }

                    }
                }
                else
                {
                    if (canDrop == true)
                    {
                        StopClipping();
                        DropObject();
                    }
                }
            }
            if (heldObj != null) //if player is holding object
            {
                MoveObject(); //keep object position at holdPos
                RotateObject();
                if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true) //Mous0 (leftclick) is used to throw, change this if you want another button to be used)
                {
                    StopClipping();
                    ThrowObject();
                }

            }
        }
        else
        {
            if (canPickupMobile)
            {
                if (heldObj == null) //if currently not holding anything
                {
                    //perform raycast to check if player is looking at object within pickuprange
                    RaycastHit hit;
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
            else
            {
                if (canDropMobile)
                {
                   StopClipping();
                   DropObject();
                }
                if (heldObj != null) //if player is holding object
                {
                    MoveObject(); //keep object position at holdPos
                    RotateObjectMobile();
                }
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
            playButton.SetActive(true);
            dropIcon.SetActive(true);
            grabIcon.SetActive(false);
            canDropMobile = false;
            canPickupMobile = false;
            scenemanager.minigameName = heldObj.GetComponent<MinigameTracker>().minigameName;
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
        if(heldObj != null && isMobileEnabled)
        {
            heldObjRb.transform.rotation = new Quaternion(0,0,0,0);
            heldObj.GetComponent<SimpleTooltip>().ShowTooltip();
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
            grabIcon.SetActive(true);
            canPickupMobile = false;
            canDropMobile = false;
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
    void RotateObject()
    {
            if (Input.GetKey(KeyCode.R))//hold R key to rotate, change this to whatever key you want
            {
                mouseLookScript.lookSpeed = 0f;

                float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
                float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
                //rotate the object depending on mouse X-Y Axis
                heldObj.transform.Rotate(Vector3.down, XaxisRotation);
                heldObj.transform.Rotate(Vector3.right, YaxisRotation);
            }
            else
            {
                //re-enable player being able to look around
                //mouseLookScript.verticalSensitivity = originalvalue;
                //mouseLookScript.lateralSensitivity = originalvalue;
                mouseLookScript.lookSpeed = 2f;
                canDrop = true;
            }
    }
    void ThrowObject()
    {
        //same as drop function, but add force to object before undefining it
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
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
