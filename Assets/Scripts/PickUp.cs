using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.ProBuilder.MeshOperations;

public class PickUp : MonoBehaviour
{
    public GameObject player;
    public SceneManagerScript scenemanager;
    public Transform holdPos;
    public float throwForce = 500f;
    public float pickUpRange = 5f;
    private GameObject heldObj;
    private Rigidbody heldObjRb;

    public string sceneName;
    private bool canDrop = false;
    private int LayerNumber;

    [SerializeField]
    private LayerMask LayerMaskPlayer;

    [SerializeField]
    private bool canThrow = false;

    FPSControler mouseLookScript;
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("HoldLayer");
        mouseLookScript = player.GetComponent<FPSControler>();
    }
    void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.F))
        { 
            if (heldObj == null)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange,~LayerMaskPlayer))
                {
                    if (hit.transform.gameObject.tag == "canPickup")
                    {
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
        if (heldObj != null)
        {
            MoveObject();
            RotateObject();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StopClipping();
                if (canThrow) ThrowObject();
                else
                {
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                    {
                        if (hit.transform.gameObject.tag == "placePos")
                        {
                            PlaceObject(hit.rigidbody.gameObject);
                        }
                    }
                }
            }
        }
    }
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            heldObj = pickUpObj;
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform;
            heldObj.layer = LayerNumber;
            if (heldObj.GetComponent<MinigameTracker>() != null) sceneName = heldObj.GetComponent<MinigameTracker>().minigame;
            //else
            //{
            //    Debug.Log("Failed");
            //}
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
            canDrop = true;
        }
        if (heldObj != null)
        {
            heldObjRb.transform.localEulerAngles = new Vector3(0, 0, 0);
            heldObjRb.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    void DropObject()
    {
        if (heldObj != null)
        {
            if (heldObj.GetComponent<MinigameTracker>() != null) sceneName = "";
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            heldObj.layer = 0;
            heldObjRb.isKinematic = false;
            heldObj.transform.parent = null;
            heldObj = null;
            canDrop = false;
        }
    }

    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldObj.transform.position = holdPos.transform.position;
    }

    void RotateObject()
    {
        if (Input.GetKey(KeyCode.E))
        {
            heldObj.transform.Rotate(0, -1f, 0);
        }
        if(Input.GetKey(KeyCode.Q)) 
        {
            heldObj.transform.Rotate(0, 1f, 0);
        }
        if(Input.GetKey(KeyCode.R))
        {
            heldObj.transform.Rotate(1,0,0);
        }
    }
    void ThrowObject()
    {
        if (heldObj.GetComponent<MinigameTracker>() != null) sceneName = "";
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
        canDrop = false;
    }
    void PlaceObject(GameObject placePosition)
    {
        if (heldObj.GetComponent<MinigameTracker>() != null) sceneName = "";
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObj.transform.parent = null;
        heldObj.transform.localPosition = new Vector3(-1.98f, 1.766f, -0.6849f);
        heldObj.transform.localEulerAngles = new Vector3(0, 5.94f, 0);
        heldObj = null;
        canDrop = false;
    }
    void StopClipping()
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
