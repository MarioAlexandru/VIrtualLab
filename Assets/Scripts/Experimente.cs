using UnityEngine;
using System.Collections;

public class Experimente : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    float distance = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("schimba scena");
        }
    }
}