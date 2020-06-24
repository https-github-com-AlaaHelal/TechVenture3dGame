using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoard : MonoBehaviour
{
    Animator Boardanimator;
    GameObject Board;
    bool openBoard;
    public bool open;
    public Transform player;
    public float Distance = 7;
    Animator Capsuleanimator;
    public GameObject[] Capsule;

    public void Start()
    {
        Board = GameObject.FindGameObjectWithTag("Board");
        Boardanimator = Board.GetComponentInParent<Animator>();
  


    }
    public void Update()
    {

        float direction = Vector3.Dot(player.forward, transform.forward);
        float distance = Vector3.Distance(player.position, transform.position);


        if (direction < 0 && Input.GetKeyDown(KeyCode.E) && distance <= Distance)
        {
            if (openBoard == false)
            {
                Boardanimator.SetBool("open", true);
                Boardanimator.SetFloat("speed", 1);
                openBoard = true;
             
            }


        }





         if (openBoard == true)
        {
            StartCoroutine(CloseCapsules());



        }


        if (openBoard == true && distance >= 20)
        {
            Boardanimator.SetBool("open", false);
            Boardanimator.SetFloat("speed", 2);
            openBoard = false;
        }


    }




    IEnumerator CloseCapsules()
    {
        yield return new WaitForSeconds(3f);

        for (int i = 0; i < 9; i++)
        {
            Capsuleanimator = Capsule[i].GetComponent<Animator>();

            Capsuleanimator.SetBool("open", false);
            Capsuleanimator.SetFloat("speed", -1);


        }
        open = false;
        yield return new WaitForSeconds(2.5f);
        FindObjectOfType<OpenCapsule>().StopAlarm();
    }







}





    

    //public void Open()
    //{
    //      if (openBoard == true)
    //     {
    //        yield return new WaitForSeconds(1f);
    //        Boardanimator.SetBool("open", false);
    //        // Boardanimator.SetBool("open", true);
    //        Boardanimator.SetFloat("speed", -2);
    //        openBoard = false;
    //    }
    //}




