using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float time = 0;
    public bool timeEnd = false;
    public TextMeshProUGUI timeText;

    // Update is called once per frame
    void Update()
    {
        if(!timeEnd)
        {
            time += Time.deltaTime * 2f;
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            if(timeSpan < TimeSpan.FromSeconds(3600))
            {
                timeText.text = "Timp: " + timeSpan.ToString("mm':'ss");
            }
            else
            {
                timeText.text = "Timp: " + timeSpan.ToString("hh':'mm':'ss");
            }  
        }    
    }


}
