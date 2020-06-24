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
    public GameObject Paper;
    public GameObject flashmemory;
    public GameObject f;
    // public Button[] buttons = new Button[17];

    public void Start()
    {




        Standanimator = Stand.GetComponentInParent<Animator>();
        flashmemory.SetActive(false);
        Paper.SetActive(false);
       f.SetActive(false);
    }


    public void Update()

    {
        if (openStand == true)
        {
           flashmemory.SetActive(true);

            StartCoroutine(Open());
            f.SetActive(true);

        }



        if (FinalCorrect==true &&Count != 18)
        {
            Screenpuzzle.SetActive(false);
            Screenpuzzle.SetActive(true);
            Count = 0;
            Debug.Log(Count);
            Debug.Log("Wrong Play again");
         

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
           // StartCoroutine(ExitCanvas());
            Screenpuzzle.SetActive(false);
            Standanimator.SetBool("open", true);
            Standanimator.SetFloat("speed", 1);
            openStand = true;
       


        }
     



    }
    IEnumerator Open()
    {
        
        yield return new WaitForSeconds(1f);
        Paper.SetActive(true);
       
    }






}








