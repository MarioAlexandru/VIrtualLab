using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeSpawn : MonoBehaviour
{
    public GameObject H2O;
    public GameObject NaCl;
    public GameObject propan;
    public GameObject metanol;
    public GameObject metan;
    public GameObject HCl;
    public GameObject etanol;
    public GameObject NH3;
    //-9,2.5,1.5
    public void spawnH2O()
    {
        Instantiate(H2O, new Vector3(-9,2,1), Quaternion.identity);

    }
    public void spawnNaCl()
    {
        Instantiate(NaCl, new Vector3(-9, 2, 1), Quaternion.identity);

    }
    public void spawnpropan()
    {
        Instantiate(propan, new Vector3(-9, 2, 1), Quaternion.identity);

    }
    public void spawnmetanol()
    {
        Instantiate(metanol, new Vector3(-9, 2, 1), Quaternion.identity);

    }
    public void spawnmetan()
    {
        Instantiate(metan, new Vector3(-9, 2, 1), Quaternion.identity);

    }
    public void spawnHCl()
    {
        Instantiate(HCl, new Vector3(-9, 2, 1), Quaternion.identity);

    }
    public void spawnetanol()
    {
        Instantiate(etanol, new Vector3(-9, 2, 1), Quaternion.identity);

    }
    public void spawnNH3()
    {
        Instantiate(NH3, new Vector3(-9, 2, 1), Quaternion.identity);

    }
}
