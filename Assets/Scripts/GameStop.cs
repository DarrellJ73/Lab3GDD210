using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStop : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0f;
        }
    }
}
