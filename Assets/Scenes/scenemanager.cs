using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    public GameObject player;
    public string minigameName;
    public bool startMinigame = false;
    private bool isMobileEnabled;

    private void Start()
    {
        isMobileEnabled = player.GetComponent<FPSControler>().isMobileEnabled;   
    }   
    void Update()
    {
        if(!isMobileEnabled)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("FaucetAndBucket");
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("FluidMaze");
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                SceneManager.LoadScene("Joculet");
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("Main");
            }
        }
        else if(startMinigame)
        {
            SceneManager.LoadScene(minigameName);
        }
    }
}
    
        
