using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WhileQuestion : MonoBehaviour
{
    public GameObject message;
    // the object and its right place
    public GameObject Whileword, WhileBox, Xword, xBox;
    // public Text message;
    public TextMeshProUGUI whiletext;
    public TextMeshProUGUI xtext;
    public TextMeshProUGUI iftext;
    public TextMeshProUGUI numtext;
    public TextMeshProUGUI whileBoxtext;
    public TextMeshProUGUI xBoxtext;


    bool oneDone, twoDone = false;
    bool oneCorrect, twoCorrect= false;
    public GameObject Educationalscript;





    public void Dropwhile()
    {

        if (oneDone == false && twoDone == false )
        {
            if (whiletext.text == "while")

            {
                whileBoxtext.text = "while";
                whiletext.text = "";



                oneDone = true;
                oneCorrect = true;

            }
        }


        else if (oneDone == true && twoDone == false )
        {
            if (whiletext.text == "while")

            {
                xBoxtext.text = "while";
                whiletext.text = "";

                twoDone = true;

            }
        }


    }

    public void ReturnBox1()
    {

        if (oneDone == true && twoDone == false )
        {
            if (whileBoxtext.text == "while")

            {
                whileBoxtext.text = "";
                whiletext.text = "while";

                oneDone = false;
                oneCorrect = false;

            }



            else if (whileBoxtext.text == "x")

            {
                xtext.text = "x";
                whileBoxtext.text = "";

                oneDone = false;

            }


            else if (whileBoxtext.text == "if")

            {
                iftext.text = "if";
                whileBoxtext.text = "";

                oneDone = false;

            }


            else if (whileBoxtext.text == "num")

            {
                numtext.text = "num";
                whileBoxtext.text = "";

                oneDone = false;

            }

        
        }

    }


    public void Dropx()

    {

        if (oneDone == false && twoDone == false)
        {
            if (xtext.text == "x")

            {
                whileBoxtext.text = "x";
                xtext.text = "";

                oneDone = true;

            }
        }

        else if (oneDone == true && twoDone == false )
        {
            if (xtext.text == "x")

            {
                xBoxtext.text = "x";
                xtext.text = "";

                twoDone = true;
                twoCorrect = true;

                Win();

            }
        }

    


    }


    public void ReturnBox2()
    {
        if (oneDone == true && twoDone == true )
        {
            if (xBoxtext.text == "while")

            {
                xBoxtext.text = "";
                whiletext.text = "while";

                twoDone = false;


            }



            else if (xBoxtext.text == "x")

            {
                xtext.text = "x";
                xBoxtext.text = "";

                twoDone = false;

            }


            else if (xBoxtext.text == "if")

            {
                iftext.text = "if";
                xBoxtext.text = "";

                twoDone = false;

            }

            else if (xBoxtext.text == "num")

            {
                numtext.text = "num";
                xBoxtext.text = "";

                twoDone = false;

            }

          

        }

    }
   

  
    public void Droptextif()

    {

        if (oneDone == false && twoDone == false)
        {
            if (iftext.text == "if")

            {
                whileBoxtext.text = "if";
                iftext.text = "";
                oneDone = true;

            }
        }

        else if (oneDone == true && twoDone == false)
        {
            if (iftext.text == "if")

            {
                xBoxtext.text = "if";
                iftext.text = "";
                twoDone = true;

            }
        }
    }



        public void Dropnum()

    {

        if (oneDone == false && twoDone == false )
        {
            if (numtext.text == "num")

            {
                whileBoxtext.text = "num";
                numtext.text = "";
                oneDone = true;

            }
        }

        else if (oneDone == true && twoDone == false )
        {
            if (numtext.text == "num")

            {
                xBoxtext.text = "num";
                numtext.text = "";
                twoDone = true;

            }
        }

     
    }




    public void Win()
    {
        if (oneCorrect == true && twoCorrect == true)
        {
            RobotManager.instance.InstantiateRobots(3);
            CardShow.instance.ShowCard(2);
            FindObjectOfType<ScoreManager>().AddScore();
            StartCoroutine(ExitQuestion());

        }
    }
    IEnumerator ExitQuestion()
    {
        
        yield return new WaitForSeconds(1.5f);
        Educationalscript.GetComponent<Educational>().QuestionPanels[3].SetActive(false);

        yield return new WaitForSeconds(.5f);
        message.SetActive(true);


        yield return new WaitForSeconds(2f);

        message.SetActive(false);
        Educationalscript.GetComponent<Educational>().Exit();


    }

}