using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    public GameObject player;
    [HideInInspector]
    public string minigameName;
    [HideInInspector] 
    public bool startMinigame = false, startStoreMinigame = false;
    private bool isMobileEnabled;

    private void Start()
    {
        isMobileEnabled = player.GetComponent<FPSControler>().isMobileEnabled;   
    }   
    void Update()
    {
        if(!isMobileEnabled)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene(minigameName);
            }
        }
        else if(startMinigame)
        {
            SceneManager.LoadScene(minigameName);
        }
        else if(startStoreMinigame)
        {
            SceneManager.LoadScene("JoculetMobile");
        }
    }
}
    
        
