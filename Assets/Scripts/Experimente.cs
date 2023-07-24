using UnityEngine;
using System.Collections;

public class Experimente : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("schimba scena");
        }
    }
}