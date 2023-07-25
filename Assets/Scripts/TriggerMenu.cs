using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu, player;

    FPSControler inputs;

    private bool isShowing = false;

    void Start()
    {
        inputs = player.GetComponent<FPSControler>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isShowing)
            {
                menu.SetActive(false);
                inputs.lookSpeed = 2f;
                inputs.canMove = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                isShowing = false;
            }
            else
            {
                menu.SetActive(true);
                inputs.lookSpeed = 0;
                inputs.canMove = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isShowing = true;
            }
        }
    }
}
