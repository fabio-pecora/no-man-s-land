using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FirstPersonDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SisterJammo")
        {
            
            SceneManager.LoadScene("WinningSCene");
        }
    }
}
