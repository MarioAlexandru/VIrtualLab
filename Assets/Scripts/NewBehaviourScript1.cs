using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript1 : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;

    public bool isMobileEnabled;
    void Start()
    {
        isMobileEnabled = player.GetComponent<FPSControler>().isMobileEnabled;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Almost there");
        if(other.gameObject == player)
        {
            Debug.Log("we in bitch");
            canvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        if (!isMobileEnabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        };
        
    }
}
