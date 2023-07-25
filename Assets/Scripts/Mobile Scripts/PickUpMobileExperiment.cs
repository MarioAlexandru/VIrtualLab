using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpMobileExperiment : MonoBehaviour
{
    public GameObject player;
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

    [HideInInspector]
    public bool canPickupMobile,
        canDropMobile,
        canRotateRightMobile,
        canRotateLeftMobile,
        canThrowMobile,
        pickedUp = false;

    [SerializeField]
    private bool canThrow;

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
            if (heldObj == null)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    if (hit.transform.gameObject.tag == "canPickup")
                    {
                        PickUpObject(hit.transform.gameObject);
                    }

                }
            }
        }
        if (heldObj != null)
        {
            MoveObject();
            RotateObjectMobile();
            if (canThrowMobile)
            {
                StopClipping();
                if (canThrow) ThrowObject();
                else
                {
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange, layerMask))
                    {
                        if (hit.transform.gameObject.tag == "placePos")
                        {
                            PlaceObject(hit.rigidbody.gameObject);
                        }
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
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            heldObj = pickUpObj;
            pickedUp = true;
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform;
            heldObj.layer = LayerNumber;
            dropIcon.SetActive(true);
            throwIcon.SetActive(true);
            grabIcon.SetActive(false);
            canDropMobile = false;
            canPickupMobile = false;
            canThrowMobile = false;
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
            if (heldObj.GetComponent<SimpleTooltip>()) heldObj.GetComponent<SimpleTooltip>().ShowTooltip();
        }
        if (heldObj != null)
        {
            heldObjRb.transform.localEulerAngles = new Vector3(0, 0, 0);
            heldObjRb.transform.localPosition = new Vector3(0, 0, 0);
            if (heldObj.GetComponent<SimpleTooltip>() != null) heldObj.GetComponent<SimpleTooltip>().ShowTooltip();
        }
    }
    void DropObject()
    {
        if (heldObj != null)
        {
            pickedUp = false;
            dropIcon.SetActive(false);
            throwIcon.SetActive(false);
            grabIcon.SetActive(true);
            canPickupMobile = false;
            canDropMobile = false;
            canThrowMobile = false;
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            heldObj.layer = 0;
            heldObjRb.isKinematic = false;
            heldObj.transform.parent = null;
            heldObj = null;
        }

    }

    void MoveObject()
    {
        heldObj.transform.position = holdPos.transform.position;
    }

    void RotateObjectMobile()
    {
        if (canRotateRightMobile)
        {
            heldObj.transform.Rotate(0, 0, -1);
        }
        else if (canRotateLeftMobile)
        {
            heldObj.transform.Rotate(0, 0, 1);
        }
    }
    void ThrowObject()
    {
        pickedUp = false;
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
        throwIcon.SetActive(false);
        dropIcon.SetActive(false);
        grabIcon.SetActive(true);
        //playButton.SetActive(false);
        canPickupMobile = false;
        canDropMobile = false;
        canThrowMobile = false;
    }

    void PlaceObject(GameObject placePosition)
    {
        pickedUp = false;
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObj.transform.parent = null;
        heldObj.transform.localPosition = new Vector3(-1.98f, 1.766f, -0.6849f);
        heldObj.transform.localEulerAngles = new Vector3(0, 5.94f, 0);
        heldObj = null;
        throwIcon.SetActive(false);
        dropIcon.SetActive(false);
        grabIcon.SetActive(true);
        canPickupMobile = false;
        canDropMobile = false;
        canThrowMobile = false;
    }
    void StopClipping()
    {
        if (heldObj != null)
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
