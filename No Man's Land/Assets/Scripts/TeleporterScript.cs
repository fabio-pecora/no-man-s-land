using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeleporterScript : MonoBehaviour
{
    public bool isPlaced;
    public GameObject teleporter;
    public Transform myTransform;

    private void Start()
    {
        isPlaced = false;
        
    }
    // Update is called once per frame
    void Update()
    {

        if (Jammo.numOfKeys == 4)
        {
            // I want to instantiate the teleporter only once
            if (isPlaced == false)
            {
                Instantiate(teleporter, myTransform);
                isPlaced = true;
                //AudioManager.instance.Play("Teleporter");


            }
        }

    }

}
