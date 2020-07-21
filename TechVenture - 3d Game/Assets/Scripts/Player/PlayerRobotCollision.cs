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
    public bool Dying;
    public bool transition;
    float Health = 110f;
    Animator animator;
    
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Dying = false;
        Debug.Log("Die");
        //animator.SetTrigger("Die");
    }

    public void TakeDamage(float amount)
    {
        //animator.SetTrigger("Die");
        if (Health == 0 && !Dying)
        {
            StartCoroutine(Die());
        }
        else if(!Dying)
        {
            Health -= amount;
            if (Health % 10 == 0)
                FindObjectOfType<LifeBar>().DecreaseLife();
            Debug.Log(Health);
            Debug.Log(FindObjectOfType<LifeBar>().health);
        }
    }
    public void IncrementHealth()
    {
        Health += 20;
        Debug.Log(Health);
        FindObjectOfType<LifeBar>().IncreaseLife();
    }
    IEnumerator Die()
    {
        Dying = true;
        animator.SetBool("Die", true);
        yield return new WaitForSeconds(1);
        transition = true;
    }
}