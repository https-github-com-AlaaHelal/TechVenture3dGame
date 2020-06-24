using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenPuzzle : MonoBehaviour
{

    Animator Standanimator;
    public GameObject Stand;
    bool openStand;
    public GameObject Screenpuzzle;
    public bool[] Correct;
    int Count;
    public  Button FirstButton;
    bool FinalCorrect;
    public GameObject Flash;
    public GameObject Paper;
    public float Distance = 7;
    public GameObject camerascript;
    public Transform cameraview;
    public Animator playeranimatore;
    public Transform player;

    public void Start()
    {

        Standanimator = Stand.GetComponentInParent<Animator>();

       Flash.SetActive(false);
        //Paper.SetActive(false);
    }


    public void Update()

    {
        if (openStand == true)
        {
           

            StartCoroutine(ActiveItemsOnStand());
         
            Debug.Log("STAND OPEN");

        }
        float direction = Vector3.Dot(player.forward,Screenpuzzle.transform.forward);
        float distance = Vector3.Distance(player.position, Screenpuzzle.transform.position);
        if (direction >0.9 && distance <= Distance)
        {
            Debug.Log(distance);
            camerascript.GetComponent<camera>().enabled = false;
            Camera.main.transform.position = cameraview.position;
            Camera.main.transform.rotation = cameraview.rotation;
            playeranimatore.gameObject.SetActive(false);

        }


        if (FinalCorrect == true && Count != 18)
        {
            Screenpuzzle.SetActive(false);

            Count = 0;
            Debug.Log(Count);
            Debug.Log("Wrong Play again");
            Screenpuzzle.SetActive(true);


        }
    }



    public void RighButton1()
    {
        Correct[0] = true;
        Count++;

    }


    public void RighButton2()
    {
        Correct[1] = true;
        Count++;
    }



    public void RighButton3()
    {
        Correct[2] = true;
        Count++;
    }


    public void RighButton4()
    {
        Correct[3] = true;
        Count++;
    }



    public void RighButton5()
    {
        Correct[4] = true;
        Count++;

    }


    public void RighButton6()
    {
        Correct[5] = true;
        Count++;
    }

    public void RighButton7()
    {
        Correct[6] = true;
        Count++;
    }

    public void RighButton8()
    {
        Correct[7] = true;
        Count++;
    }

    public void RighButton9()
    {
        Correct[8] = true;
        Count++;
    }

    public void RighButton10()
    {
        Correct[9] = true;
        Count++;
    }

    public void RighButton11()
    {
        Correct[10] = true;
        Count++;
    }

    public void RighButton12()
    {
        Correct[11] = true;
        Count++;
    }

    public void RighButton13()
    {
        Correct[12] = true;
        Count++;
    }

    public void RighButton14()
    {
        Correct[13] = true;
        Count++;
    }
    public void RighButton15()
    {
        Correct[14] = true;
        Count++;
    }

    public void RighButton16()
    {
        Correct[15] = true;
        Count++;
       
    }
    public void RighButton17()
    {
        Correct[16] = true;
        Count++;
        Debug.Log(Count);

    }
    public void FinalButton()

    {
        FinalCorrect= true;
        Count++;
        Debug.Log(Count);
        if (Count == 18)
        {

          
            camerascript.GetComponent<camera>().enabled = true;

            playeranimatore.gameObject.SetActive(true);
          //  Destroy(Screenpuzzle);
            Standanimator.SetBool("open", true);
            Standanimator.SetFloat("speed", 1);
            openStand = true;
       


        }
     



    }


    IEnumerator ActiveItemsOnStand()
    {
       
        yield return new WaitForSeconds(1.5f);

        Flash.SetActive(true);
        Paper.SetActive(true);


    }




}








