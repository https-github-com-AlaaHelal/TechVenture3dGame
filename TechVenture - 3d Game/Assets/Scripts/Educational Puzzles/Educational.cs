using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Educational : MonoBehaviour
{
    public Canvas ScreenCanvas;
    public Animator[] ballAnimatore = new Animator[20];
    public Animator baseScreen;
    public Animator Screen;
    public GameObject[] Balls = new GameObject[20];
    public GameObject[] InformationText = new GameObject[10];
    public  GameObject[] QuestionPanels = new GameObject[10];
    int Number;
    public GameObject masgg;

    // Start is called before the first frame update
    void Start()
    {
        //deactive canvas and texts;
       ScreenCanvas.enabled = false;

        for (int i = 0; i < 10; i++)
        {
            InformationText[i].SetActive(false);
            QuestionPanels[i].SetActive(false);
        }


    }
  
    //when touch the ball 
    void OnTriggerEnter(Collider Ball)
    {
        if (Ball.gameObject.tag == "BinaryInformation")
        {
            Number = 0;
            Display();

        }
        if (Ball.gameObject.tag == "LogicInformation")
        {
            Number = 1;
            Display();

        }
        if (Ball.gameObject.tag == "BinaryQuestion")
        {
            Number = 10;
            Display();


        }
        if (Ball.gameObject.tag == "LogicQuestion")
        {
            Number = 11;
            Display();


        }
    }
    //Display screen
    void Display()
    {
        ballAnimatore[Number].SetBool("is interacted", true);
        ScreenCanvas.enabled = true;
        StartCoroutine(TimeToShowScreen(Number));

    }
    IEnumerator TimeToShowScreen(int Number)
    {

        yield return new WaitForSeconds(4f);
        baseScreen.SetBool("open", true);
        yield return new WaitForSeconds(2f);
        Screen.SetBool("open", true);
        yield return new WaitForSeconds(1.5f);
        DisplayInformationORQuestion(Number);




    }
    //hide screen when Exit
    IEnumerator TimeToHideScreen(int Number)
    {
      
        yield return new WaitForSeconds(.5f);
        HideInformationORQuestion(Number);
        yield return new WaitForSeconds(1f);
        Screen.SetBool("open", false);
        yield return new WaitForSeconds(1f);
        baseScreen.SetBool("open", false);
        yield return new WaitForSeconds(1.5f);
        ScreenCanvas.enabled = false;

    }
    
   
    void DisplayInformationORQuestion(int Number)
    {
        if (Number < 10)
        {
            InformationText[Number].gameObject.SetActive(true);
            Balls[Number].SetActive(false);

        }
        if (Number >= 10)
        {

            QuestionPanels[Number - 10].gameObject.SetActive(true);
            Balls[Number].SetActive(false);

        }
    }
    void HideInformationORQuestion(int Number)
    {
        if (Number < 10)
        {
            InformationText[Number].gameObject.SetActive(false);
        }
        if (Number >= 10)
            
        {   

            QuestionPanels[Number - 10].gameObject.SetActive(false);
        }
    }
   public void Exit()
    {
        StartCoroutine(TimeToHideScreen(Number));
    }


}
