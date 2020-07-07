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
        if(Health % 10 == 0)
            FindObjectOfType<LifeBar>().DecreaseLife();
        //if (Health <= 0)
        //{
        //    Die();
        //}
    }
    public void IncrementHealth()
    {
        Health += 20;
        Debug.Log(Health);
        FindObjectOfType<LifeBar>().IncreaseLife();
    }
    void Die()
    {
        Debug.Log("Die");
    }
}