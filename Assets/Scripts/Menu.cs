using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject player;

    FPSControler inputs;
    private void Awake()
    {
        inputs = player.GetComponent<FPSControler>();
    }
    public void OnResume()
    {
        gameObject.SetActive(false);
        inputs.lookSpeed = 2f;
        inputs.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnReturn()
    {
        SceneManager.LoadScene("Laborator");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
