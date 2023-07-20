using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class StartUI : MonoBehaviour, IPointerDownHandler
{

    public GameObject timeManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        timeManager.GetComponent<TimeManager>().timeEnd = false;
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("pieces");
        foreach(GameObject piece in pieces)
        {
            piece.GetComponent<PuzzlePiece>().canBePickedUp = true;
        }
    }
}
