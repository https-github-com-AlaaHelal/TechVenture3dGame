using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //public GameObject Power;
    private bool PoweredUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (! PoweredUp && other.CompareTag("Player"))
        {
            other.GetComponent<PlayerRobotCollision>().IncrementHealth();
            PoweredUp = true;
            Destroy(gameObject);
        }
           
    }
}
