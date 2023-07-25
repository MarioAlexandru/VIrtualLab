using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMobile : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private TriggerMenuMobile triggerMenuMobile;

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
        settingsButton.SetActive(true);
        triggerMenuMobile.canOpenMenu = false;
    }

    public void OnReturn()
    {
        SceneManager.LoadScene("Laborator Main Mobile");
    }
}
