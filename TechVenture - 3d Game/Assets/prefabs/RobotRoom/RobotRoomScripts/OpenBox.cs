using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    Animator Boxanimator;
    public GameObject Box;
    public GameObject LasrInBox;

    bool openbox;
    public Transform player;
    public float Distance = 7;
 

    public void Start()
    {
        Box= GameObject.FindGameObjectWithTag("Box");
        Boxanimator = Box.GetComponentInParent<Animator>();
        LasrInBox.SetActive(false);
    }
    public void Update()
    {

        float direction = Vector3.Dot(player.forward, transform.forward);
        float distance = Vector3.Distance(player.position, transform.position);


        //if (Input.GetKeyDown(KeyCode.E) && distance <= Distance)
        //{
        //    //MovBlockCanvas.SetActive();
        //    //if (openbox == false)
        //    //{
        //    //    Boxanimator.SetBool("open", true);
        //    //    Boxanimator.SetFloat("speed", 1);
        //    //    openbox = true;
        //    //    LasrInBox.SetActive(true);


        //    //}


        //}

        if (distance > 15 && openbox == true)
        {

            Boxanimator.SetBool("open",false);
            Boxanimator.SetFloat("speed", 1);
            openbox = false;



        }


    }
}