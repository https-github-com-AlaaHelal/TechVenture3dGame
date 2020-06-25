using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRobotCollision : MonoBehaviour
{
    // Start is called before the first frame update
    //public void OnTriggerEnter(Collider collider)
    //{


    //    if (collider.gameObject.tag == "Robot")
    //    {
    //        FindObjectOfType<LifeBar>().DecreaseLife();

    //    }


    //}
    float Health = 50f;

    public void TakeDamage(float amount)
    {
        Health -= amount;
        //sFindObjectOfType<LifeBar>().DecreaseLife();
        if (Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Die");
    }
}