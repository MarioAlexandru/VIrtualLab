using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment1Board : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private SceneManagerScript scenes;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            scenes.minigameName = "Experiment 1";
            GetComponent<SimpleTooltip>().ShowTooltip();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            scenes.minigameName = "";
            GetComponent<SimpleTooltip>().HideTooltip();
        }
    }
}
