using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    GameObject BoardGame;
    public GameObject LaserInBox;
    GameObject Box;
    Animator Boxanimator;
    public GameObject Camera;

    public void Manager()

    {
        Camera.GetComponent<camera>().enabled = true;
        BoardGame = GameObject.FindGameObjectWithTag("BlockBoard");
        Destroy(BoardGame);
        Box = GameObject.FindGameObjectWithTag("Box");
        Boxanimator = Box.GetComponentInParent<Animator>();
        Boxanimator.SetBool("open", true);
        Boxanimator.SetFloat("speed", 1);
     
        LaserInBox.SetActive(true);


    }


}
