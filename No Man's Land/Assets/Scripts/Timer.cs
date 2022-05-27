using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public static float secondsLeft = 25;
    public GameObject textDisplay;

    void Start()
    {
        textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "00:0" + secondsLeft;
    }

    void Update()
    {
        secondsLeft -= 1 * Time.deltaTime;
        if(secondsLeft > 10)
        {
            textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "00:" + Math.Round(secondsLeft);
        }
        else
        {
            textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "00:0" + Math.Round(secondsLeft);
        }

        if(secondsLeft >= 15)
        {
            textDisplay.GetComponent<TMPro.TextMeshProUGUI>().color = Color.green;
        }
        else if(secondsLeft > 7 && secondsLeft <= 15)
        {
            textDisplay.GetComponent<TMPro.TextMeshProUGUI>().color = Color.yellow;
        }
        else
        {
            textDisplay.GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
        }
        
        
       
    }
}

