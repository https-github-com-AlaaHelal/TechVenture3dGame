using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenPuzzle : MonoBehaviour
{

    Animator Standanimator;
    GameObject Stand;
    bool openStand;
    public GameObject Screenpuzzle;
    public bool[] Correct;
    public  Button FirstButton;
    bool FinalCorrect;
    public GameObject Flash;
    public GameObject Paper;
    public float Distance = 7;
    public Transform player;
   // bool Done;
    public void Start()
    {
        Stand = GameObject.FindGameObjectWithTag("Stand");
        Standanimator = Stand.GetComponentInParent<Animator>();

        Flash.SetActive(false);
        Paper.SetActive(false);
    }


    public void Update()

    {

        if (openStand == true)
        {


            StartCoroutine(ActiveItemsOnStand());

           // Debug.Log("STAND OPEN");

        }
    


    
    }

    public void Win()
    {
        if (Correct[0] == true && Correct[1] == true && Correct[2] == true && Correct[3] == true && Correct[4] == true && Correct[5] == true && Correct[6] == true && Correct[7] == true && Correct[8] == true && Correct[9] == true && Correct[10] == true && Correct[11] == true && Correct[12] == true && Correct[13] == true && Correct[14] == true && Correct[15] == true && Correct[16] == true && FinalCorrect== true)
        {
            Standanimator.SetBool("open", true);
            Standanimator.SetFloat("speed", 1);

            openStand = true;
            StartCoroutine(ActiveItemsOnStand());
            Destroy(Screenpuzzle);
            //Done = true;
           
        }
    }

    public void RighButton1()
    {
        Correct[0] = true;
       
      
    }


    public void RighButton2()
    {
        Correct[1] = true;
    }



    public void RighButton3()
    {
        Correct[2] = true;
       
   
    }


    public void RighButton4()
    {
        Correct[3] = true;
    }



    public void RighButton5()
    {
        Correct[4] = true;

    }


    public void RighButton6()
    {
        Correct[5] = true;
    }

    public void RighButton7()
    {
        Correct[6] = true;
    }

    public void RighButton8()
    {
        Correct[7] = true;
    }

    public void RighButton9()
    {
        Correct[8] = true;
    }

    public void RighButton10()
    {
        Correct[9] = true;
        
    }

    public void RighButton11()
    {
        Correct[10] = true;
        
    }

    public void RighButton12()
    {
        Correct[11] = true;
       
    }

    public void RighButton13()
    {
        Correct[12] = true;
    
    }

    public void RighButton14()
    {
        Correct[13] = true;
       
    }
    public void RighButton15()
    {
        Correct[14] = true;
     
    }

    public void RighButton16()
    {
        Correct[15] = true;
    
       
    }
    public void RighButton17()
    {
        Correct[16] = true;
      

    }
    public void FinalButton()

    {
        FinalCorrect = true;
        Win();
     

    }


    IEnumerator ActiveItemsOnStand()
    {
       
        yield return new WaitForSeconds(5f);

        Flash.SetActive(true);
        Paper.SetActive(true);



    }
    public void exit()
    {

        Screenpuzzle.SetActive(false);
    
    }




}








