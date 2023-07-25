using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMenuMobile : MonoBehaviour
{
    [SerializeField]
    private GameObject menu, player,settingsButton;

    FPSControler inputs;

    [HideInInspector]
    public bool canOpenMenu;

    void Start()
    {
        inputs = player.GetComponent<FPSControler>();
    }
    void Update()
    {
        if (canOpenMenu)
        {
            menu.SetActive(true);
            inputs.lookSpeed = 0;
            inputs.canMove = false;
            settingsButton.SetActive(false);
            canOpenMenu = false;
        }
        else
        {
            inputs.lookSpeed = 2f;
            inputs.canMove = true;
        }
    }
}
