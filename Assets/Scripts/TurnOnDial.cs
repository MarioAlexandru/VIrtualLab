using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnOnDial : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles;

    [SerializeField]
    private Transform dial;

    [SerializeField]
    private Transform cameraTransform;

    private bool canTurn = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out hit, 10))
            {
                if (hit.transform == dial)
                {
                    if (!canTurn)
                    {
                        canTurn = true;
                        dial.Rotate(0, 190, 0);
                        particles.gameObject.SetActive(true);
                        particles.Play();
                    }
                    else
                    {
                        canTurn = false;
                        dial.Rotate(0, -190, 0);
                        particles.Stop();
                    }
                }
            }
        }
    }
    IEnumerator WaitForFlameToStop()
    {
        yield return new WaitForSeconds(1);
        particles.gameObject.SetActive(false);
    }
}
