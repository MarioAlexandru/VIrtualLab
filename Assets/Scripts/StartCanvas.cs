using UnityEngine;


public class StartCanvas : MonoBehaviour
{

    //defines that the canvas has been presented to the user, so we set it to disabled.
    internal static bool presentedToUser = false;
    public GameObject player;
    bool isMobileEnabled;

    // Use this for initialization
    void Start()
    {
        isMobileEnabled = player.GetComponent<FPSControler>().isMobileEnabled;
        if(!isMobileEnabled )
        {
            if (presentedToUser == false)
            {
                gameObject.SetActive(true);
                player.GetComponent<FPSControler>().enabled = false;
            }
            else
            {
                gameObject.SetActive(false);
                player.GetComponent<FPSControler>().enabled = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMobileEnabled) 
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A)
                || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)
                || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
                || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.SetActive(false);
                presentedToUser = true;
                player.GetComponent<FPSControler>().enabled = true;
            }
        }
        else
        {
            if(Input.touchCount == 1 || Input.GetMouseButton(0))
            {
                gameObject.SetActive(false);
                presentedToUser = true;
                player.GetComponent <FPSControler>().enabled = true;
            }
        }
        
    }
}
