using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfQuestion : MonoBehaviour

{
    public Button WrongAnswerButton;
    public Button RightAnswerButton;
    public GameObject Educationalscript;
    public GameObject WinningMessage;
    public Sprite trueimg;
    int checkscore=0;


    //public void UserSelectFalse()
    //{

    //}
    public void UserSelectTrue()
    {
        WrongAnswerButton.image.sprite = trueimg;
        RightAnswerButton.image.sprite = trueimg;
        WrongAnswerButton.enabled = false;
        RightAnswerButton.enabled = false;
        StartCoroutine(ExitQuestion());


        checkscore++;
        if (checkscore == 1)
        {
            FindObjectOfType<ScoreManager>().AddScore();
        }


    }
    IEnumerator ExitQuestion()
    {
        yield return new WaitForSeconds(1.5f);
        Educationalscript.GetComponent<Educational>().QuestionPanels[2].SetActive(false);
        // QuestionPanels[0].SetActive(false);
        yield return new WaitForSeconds(.5f);
        WinningMessage.SetActive(true);

        //  masgg.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        //  Destroy(masgg.gameObject);
        WinningMessage.SetActive(false);
        Educationalscript.GetComponent<Educational>().Exit();


    }
    } 