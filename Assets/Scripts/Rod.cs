using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    public Transform flameSpawn;
    public ParticleSystem flames;

    private Element selectedElement;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if (other.gameObject.CompareTag("Element"))
        {
            selectedElement = other.gameObject.GetComponent<Element>();
            if (selectedElement != null)
            {
                GameManagerExperiment.Instance.ShowSelectedElement(selectedElement);
            }
        }
        else if (flames.isPlaying)
        {
           
            if (other.gameObject.CompareTag("Flame"))
            {
                if (selectedElement != null)
                {
                    GameManagerExperiment.Instance.ShowElementColour(selectedElement);
                    foreach (Transform child in flameSpawn)
                    {
                        Destroy(child.gameObject);
                    }
                    GameObject flame = Instantiate(selectedElement.ParticlePrefab, flameSpawn);
                    flame.transform.localPosition = Vector3.zero;
                    flame.transform.localRotation = Quaternion.Euler((this.transform.rotation.z - 90), 0f, 0f);

                    selectedElement = null;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Flame"))
        {
            GameManagerExperiment.Instance.HideElementText();
            foreach(Transform child in flameSpawn)
            {
                child.GetComponent<ParticleSystem>().Stop();
            }
        }
    }




}