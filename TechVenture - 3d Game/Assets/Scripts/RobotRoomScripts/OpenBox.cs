using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    Animator Boxanimator;
    public GameObject Box;
    public GameObject BoxOutLine;
    bool openbox;
    public Transform player;
    public float Distance = 7;
    public GameObject MoveBlockCanvas;
    public GameObject Camera;

    public void Start()
    {
        Box= GameObject.FindGameObjectWithTag("Box");
        Boxanimator = Box.GetComponentInParent<Animator>();
        BoxOutLine.SetActive(false);
    }
    public void Update()
    {

        float direction = Vector3.Dot(player.forward, transform.forward);
        float distance = Vector3.Distance(player.position, transform.position);


        //if ( distance <= Distance)
        //{
        //    BoxOutLine.SetActive(true);
    
        //}
        //else   BoxOutLine.SetActive(false);

        if (distance <= Distance && Input.GetKeyDown(KeyCode.E) && MoveBlockCanvas!=null) 
        { 
            MoveBlockCanvas.SetActive(true);

            Camera.GetComponent<camera>().enabled = false;



        }

        if (distance > 15 && openbox == true)
        {

            Boxanimator.SetBool("open",false);
            Boxanimator.SetFloat("speed", 1);
            openbox = false;

        }


    }

    public void exit()
    {
        MoveBlockCanvas.SetActive(false);
    }

}