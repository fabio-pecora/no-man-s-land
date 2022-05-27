using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject blueMazeDoor;
    [SerializeField] GameObject redMazeDoor;
    [SerializeField] GameObject blackMazeDoor;
    [SerializeField] GameObject sandyMazeDoor;

    public bool activeTile = true;
    public int check = 0;

    //colliging with the tile in the middle of all the maze doors
    void OnTriggerEnter(Collider col)
    {
        
        if (Jammo.numOfKeys > check)
        {
            Debug.Log("test");
            activeTile = true;
            check++;
        }

        if (activeTile)
        {
            Debug.Log("tile");
            if (Jammo.numOfKeys == 0)
            {

                sandyMazeDoor.transform.position += new Vector3(0, -10, 0);//opens the sandy maze door
                activeTile = false;

            }
            else if (Jammo.numOfKeys == 1)
            {

                sandyMazeDoor.transform.position += new Vector3(0, 10, 0); //closes the sandy maze door
                blueMazeDoor.transform.position += new Vector3(0, -10, 0); //opens the blue maze door
                activeTile = false;
            }
            else if (Jammo.numOfKeys == 2)
            {

                blueMazeDoor.transform.position += new Vector3(0, 10, 0);//closes the blue maze door
                redMazeDoor.transform.position += new Vector3(0, -10, 0);//opens the red maze door
                activeTile = false;

            }
            else if (Jammo.numOfKeys == 3)
            {

                redMazeDoor.transform.position += new Vector3(0, 10, 0);//closes the red maze door
                blackMazeDoor.transform.position += new Vector3(0, -10, 0);//opens the black maze door
                activeTile = false;

            }
        }
        

        //isOpened is pointless keeping it here just in case
        //if (!isOpened && Jammo.numOfKeys == 0)
        //{
        //    isOpened = true;
        //    sandyMazeDoor.transform.position += new Vector3(0, -10, 0);
        //    isOpened = false;
        //}
        //else if (!isOpened && Jammo.numOfKeys == 1)
        //{
        //    isOpened = true;
        //    blueMazeDoor.transform.position += new Vector3(0, -10, 0);
        //    sandyMazeDoor.transform.position += new Vector3(0, 10, 0);
        //    isOpened = false;
        //}
        //else if (!isOpened && Jammo.numOfKeys == 2)
        //{
        //    isOpened = true;
        //    redMazeDoor.transform.position += new Vector3(0, -10, 0);
        //    blueMazeDoor.transform.position += new Vector3(0, 10, 0);
        //    isOpened = false;
        //}
        //else if (!isOpened && Jammo.numOfKeys == 3)
        //{
        //    isOpened = true;
        //    blackMazeDoor.transform.position += new Vector3(0, -10, 0);
        //    redMazeDoor.transform.position += new Vector3(0, 10, 0);
        //    isOpened = false;
        //}
    }
}
