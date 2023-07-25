using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript1 : MonoBehaviour
{
    FPSControler playerController;
    public SceneManagerScript scenes;

    public GameObject canvas;
    public GameObject player;
    
    public GameObject playStoreButton= null;
    public GameObject openStoreButton = null;
    public GameObject closeStoreButton = null;

    private bool isMobileEnabled;
    private bool canTrigger;
    private bool menuIsShowing = false;

    [HideInInspector] public bool openShopMobile,closeShopMobile;
    void Start()
    {
        isMobileEnabled = player.GetComponent<FPSControler>().isMobileEnabled;
        playerController = player.GetComponent<FPSControler>();
    }

    private void Update()
    {
        if (!isMobileEnabled)
        {
            if (canTrigger)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    if (menuIsShowing)
                    {
                        canvas.SetActive(false);
                        playerController.lookSpeed = 2f;
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                        menuIsShowing = false;
                        scenes.minigameName = "";
                    }
                    else
                    {
                        playerController.lookSpeed = 0f;
                        canvas.SetActive(true);
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        menuIsShowing = true;
                        scenes.minigameName = "Joculet";
                    }
                }
            }
            else
            {
                canvas.SetActive(false);
                playerController.lookSpeed = 2f;
                menuIsShowing = false;
                scenes.minigameName = "";
            }
        }
        else
        {
            if(canTrigger)
            {
                if (closeShopMobile)
                {
                    canvas.SetActive(false);
                    playerController.lookSpeed = 2f;
                    playStoreButton.SetActive(false);
                    closeStoreButton.SetActive(false);
                    openStoreButton.SetActive(true);
                    closeShopMobile = false;
                    openShopMobile = false;
                }
                else if (openShopMobile)
                {
                    playerController.lookSpeed = 0f;
                    canvas.SetActive(true);
                    playStoreButton.SetActive(true);
                    closeStoreButton.SetActive(true);
                    openStoreButton.SetActive(false);
                    closeShopMobile = false;
                    openShopMobile = false;
                }
            }
            else
            {
                canvas.SetActive(false);
                playerController.lookSpeed = 2f;
                menuIsShowing = false;
                playStoreButton.SetActive(false);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            canTrigger = true;
            if (isMobileEnabled)
            {
                openStoreButton.SetActive(true);
                openShopMobile = false;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            canTrigger = false;
            if (isMobileEnabled)
            {
                openStoreButton.SetActive(false);
                closeStoreButton.SetActive(false);
                openShopMobile = false;
                closeShopMobile = false;
            }
        }
    }
}
