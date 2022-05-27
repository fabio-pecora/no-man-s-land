using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    static public Transform POWERUPS_HOLDER;
    [Header("Set in Inspector")]
    public GameObject[] PowerUpsType;

    [Header("Set Dynamically")]
    public GameObject pu;
    public float speed = 0f;

    

    // Start is called before the first frame update
    void Awake()
    {
        speed = 0.7f;

        //Instantiating the random powertypes to the container 
        pu = Instantiate<GameObject>(PowerUpsType[Random.Range(0, 3)]);

        //Giving all the Powerups a parent folder
        if (POWERUPS_HOLDER == null)
        {
            GameObject go = new GameObject("_PowerUpsHolder");
            POWERUPS_HOLDER = go.transform;

        }
        pu.transform.SetParent(POWERUPS_HOLDER, true); 

        //Setting the Powertypes to the postion and direction of the Container
        if (this.transform.eulerAngles.y == 90 && pu.transform.eulerAngles.y != 90)
        {
            float yRotation = this.transform.eulerAngles.y;
            pu.transform.eulerAngles = new Vector3(pu.transform.eulerAngles.x, yRotation, pu.transform.eulerAngles.z);
        }
        pu.transform.position = this.transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        //Bouncing the powerups up and down
        Vector3 pos = this.transform.position;
        pos.y += speed * Time.deltaTime;
        this.transform.position = pos;
        if (pos.y > 0.5f)
        {
            speed = -Mathf.Abs(speed);
        }else if (pos.y < 0.25f){
            speed = Mathf.Abs(speed);
        }

        pu.transform.position = this.transform.position;

    }

    //returning the powertype of the given to this container
    public GameObject PowerUpType()
    {
        return pu;
    }

}
