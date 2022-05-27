using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI Keys;
    public TextMeshProUGUI level;
    public Text damageTimeLeft;


    // Start is called before the first frame update
    void StartLevel()
    {
        UpdateGUI();
    }

    // Update is called once per frame
    void UpdateGUI()
    {

        
        if (Jammo.damageAbsorbed)
        {
            //Debug.Log("UI hello");

            damageTimeLeft.text = "2X damage: " + Mathf.Round(Jammo.damageUI) + "s";
        }
        else
        {
            damageTimeLeft.text = " ";
        }

        Keys.text = "KEYS: " + Jammo.numOfKeys;
        level.text = "LEVEL: " + Jammo.level;

        Debug.Log("damage: " + Jammo.damage);
    }

    void Update()
    {
        UpdateGUI();
    }
}
