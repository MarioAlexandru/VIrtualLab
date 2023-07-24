using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisions : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hit");
    }
}
