using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gobackMobile : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("Laborator Main Mobile");
    }
}
