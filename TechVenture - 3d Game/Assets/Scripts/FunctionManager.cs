using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//inform unity that class can store informaion
[System.Serializable]
public class FunctionManager : MonoBehaviour {

    // the object and its right place
    public GameObject intword, intBox, result, resultBox, AddFunction, AddFunctionBox;
   // public Text message;
    public TextMeshProUGUI inttext;
    public TextMeshProUGUI resulttext;
    public TextMeshProUGUI voidtext;
    public TextMeshProUGUI returntext;
    public TextMeshProUGUI addfunctiontext;
    public TextMeshProUGUI intBoxtext;
    public TextMeshProUGUI resultBoxtext;
    public TextMeshProUGUI AddFunctionBoxtext;


    bool oneDone, twoDone, threeDone = false;
    bool oneCorrect, twoCorrect, threeCorrect = false;
    public GameObject Educationalscript;

    [SerializeField]


    //****************************************Drop


    public void Dropint()
    {
        Debug.Log("hey");
        if (oneDone == false && twoDone == false && threeDone == false)
        {
            if (inttext.text == "int")

            {
                intBoxtext.text = "int";
                inttext.text = "";
           
               
               
                oneDone = true;
                oneCorrect = true;
             
            }
        }


        else if (oneDone == true && twoDone == false && threeDone == false)
        {
            if (inttext.text == "int")

            {
                resultBoxtext.text = "int";
                inttext.text = "";
             
                twoDone = true;
               
            }
        }

        else if (oneDone == true && twoDone == true && threeDone == false)
        {
            if (inttext.text == "int")

            {
                AddFunctionBoxtext.text = "int";
                inttext.text = "";
          
                threeDone = true;
             
            }
        }
    
    }

    public void ReturnBox1()
    {

        if (oneDone == true && twoDone == false && threeDone == false)
        {
            if (intBoxtext.text == "int")

            {
                intBoxtext.text = "";
                inttext.text = "int";

                oneDone = false;
                oneCorrect = false;

            }



            else if (intBoxtext.text == "result")

            {
                resulttext.text = "result";
                intBoxtext.text = "";

                oneDone = false;

            }


            else if (intBoxtext.text == "AddFunction")

            {
                addfunctiontext.text = "AddFunction";
                intBoxtext.text = "";

                oneDone = false;

            }


            else if (intBoxtext.text == "void")

            {
                voidtext.text = "void";
                intBoxtext.text = "";

                oneDone = false;

            }

            else if (intBoxtext.text == "return")

            {
               returntext.text = "return";
                intBoxtext.text = "";

                oneDone = false;

            }
        }

    }


    public void Dropresult()

    {

        if (oneDone == false && twoDone == false && threeDone == false)
        {
            if (resulttext.text == "result")

            {
                intBoxtext.text = "result";
                resulttext.text = "";
              
                oneDone = true;
              
            }
        }

        else if (oneDone == true && twoDone == false && threeDone == false)
        {
            if (resulttext.text == "result")

            {
                resultBoxtext.text = "result";
                resulttext.text = "";
              
                twoDone = true;
                twoCorrect = true;
               
            }
        }

        else if (oneDone == true && twoDone == true && threeDone == false)
        {
            if (resulttext.text == "result")

            {
                AddFunctionBoxtext.text = "result";
                resulttext.text = "";
           
                threeDone = true;
               
            }
        }
     



    }


    public void ReturnBox2()
    {
        if (oneDone == true && twoDone == true && threeDone == false)
        {
            if (resultBoxtext.text == "int")

            {
                resultBoxtext.text = "";
                inttext.text = "int";

                twoDone = false;
               

            }



            else if (resultBoxtext.text == "result")

            {
                resulttext.text = "result";
                resultBoxtext.text = "";

                twoDone = false;

            }


            else if (resultBoxtext.text == "AddFunction")

            {
                addfunctiontext.text = "AddFunction";
                resultBoxtext.text = "";

                twoDone = false;

            }

            else if (resultBoxtext.text == "void")

            {
                voidtext.text = "void";
                resultBoxtext.text = "";

                twoDone = false;

            }

            else if (resultBoxtext.text == "return")

            {
                returntext.text = "return";
                resultBoxtext.text = "";

                twoDone = false;

            }

        }

    }
    public void DropAddFunction()
    {



        if (oneDone == false && twoDone == false && threeDone == false)
        {
            if (addfunctiontext.text == "AddFunction")

            {
                intBoxtext.text = "AddFunction";
                addfunctiontext.text = "";
       
                oneDone = true;
               
            }
   
        }


        else if (oneDone == true && twoDone == false && threeDone == false)
        {
            if (addfunctiontext.text == "AddFunction")

            {
                resultBoxtext.text = "AddFunction";
                addfunctiontext.text = "";
             
                twoDone = true;
               
            }
        }

        else if (oneDone == true && twoDone == true && threeDone == false)
        {
            if (addfunctiontext.text == "AddFunction")

            {
                AddFunctionBoxtext.text = "AddFunction";
                addfunctiontext.text = "";
            
                threeDone = true;
                threeCorrect = true;
                Win();

            }
        }
   
        

    }

    public void ReturnBox3()
    {
        if (oneDone == true && twoDone == true && threeDone == true)
        {
            if (AddFunctionBoxtext.text == "int")

            {
                AddFunctionBoxtext.text = "";
                inttext.text = "int";

                threeDone = false;


            }



            else if (AddFunctionBoxtext.text == "result")

            {
               resulttext.text = "result";
                AddFunctionBoxtext.text = "";

                threeDone = false;

            }


            else if (AddFunctionBoxtext.text == "AddFunction")

            {
                addfunctiontext.text = "AddFunction";
                AddFunctionBoxtext.text = "";

                threeDone = false;

            }


            else if (AddFunctionBoxtext.text == "void")

            {
                voidtext.text = "void";
                AddFunctionBoxtext.text = "";

                threeDone = false;

            }


            else if (AddFunctionBoxtext.text == "return")

            {
               returntext.text = "return";
                AddFunctionBoxtext.text = "";

                threeDone = false;

            }



        }

    }


    public void Dropvoid()

    {

        if (oneDone == false && twoDone == false && threeDone == false)
        {
            if (voidtext.text == "void")

            {
                intBoxtext.text = "void";
                voidtext.text = "";
                oneDone = true;

            }
        }

        else if (oneDone == true && twoDone == false && threeDone == false)
        {
            if (voidtext.text == "void")

            {
                resultBoxtext.text = "void";
                voidtext.text = "";
                twoDone = true;

            }
        }

        else if (oneDone == true && twoDone == true && threeDone == false)
        {
            if (voidtext.text == "void")

            {
                AddFunctionBoxtext.text = "void";
                voidtext.text = "";

                threeDone = true;
            }
        }
    }

    public void Dropreturn()

    {

        if (oneDone == false && twoDone == false && threeDone == false)
        {
            if (returntext.text == "return")

            {
                intBoxtext.text = "return";
                returntext.text = "";
                oneDone = true;

            }
        }

        else if (oneDone == true && twoDone == false && threeDone == false)
        {
            if (returntext.text == "return")

            {
                resultBoxtext.text = "return";
                returntext.text = "";
                twoDone = true;

            }
        }

        else if (oneDone == true && twoDone == true && threeDone == false)
        {
            if (returntext.text == "return")

            {
                AddFunctionBoxtext.text = "return";
                returntext.text = "";

                threeDone = true;
            }
        }
    }

    //public void Update()
    //{ if (oneCorrect==true && twoCorrect==true && threeCorrect==true)
         
    //    {
    //        Debug.Log("WINNER");

    //        //message.color = Color.green;
    //        //message.text = "Great";
    //        StartCoroutine(TransitionToNextQuestion());
    //    }
    //}



    public void Win()
    {

        //b1.image.sprite = trueimg;
        //b2.image.sprite = trueimg;
        //b3.image.sprite = trueimg;
        //b4.image.sprite = trueimg;
        //b5.image.sprite = trueimg;
        if (oneCorrect == true && twoCorrect == true && threeCorrect == true)
        {
            StartCoroutine(ExitQuestion());
            FindObjectOfType<ScoreManager>().AddScore();
        }
    }
    IEnumerator ExitQuestion()
    {
        yield return new WaitForSeconds(1.5f);
        Educationalscript.GetComponent<Educational>().QuestionPanels[0].SetActive(false);
        // QuestionPanels[0].SetActive(false);
        yield return new WaitForSeconds(.5f);
        Educationalscript.GetComponent<Educational>().masgg.SetActive(true);

        //  masgg.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        //  Destroy(masgg.gameObject);
        Educationalscript.GetComponent<Educational>().masgg.SetActive(false);
        Educationalscript.GetComponent<Educational>().Exit();


    }



}