using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public GameObject Educationalscript;
    public GameObject winningmassg;
    public GameObject losemassg;


    // Start is called before the first frame update
    void Start()
    {
        winningmassg.SetActive(false);
        losemassg.SetActive(false);


    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
    public void True()
    {

        FindObjectOfType<ScoreManager>().AddScore();
        StartCoroutine(ExitQuestion());
    }
    public void False()
    {
        StartCoroutine(ExitQuestionfalse());
    }
    IEnumerator ExitQuestion()
    {
        RobotManager.instance.InstantiateRobots(3);
        CardShow.instance.ShowCard("Logic");
        yield return new WaitForSeconds(1.5f);
        Educationalscript.GetComponent<Educational>().QuestionPanels[1].SetActive(false);
        // QuestionPanels[0].SetActive(false);
        yield return new WaitForSeconds(.5f);
        winningmassg.SetActive(true);

        //  masgg.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        //  Destroy(masgg.gameObject);
        winningmassg.SetActive(false);
        Educationalscript.GetComponent<Educational>().Exit();

    }
    IEnumerator ExitQuestionfalse()
    {
        yield return new WaitForSeconds(1.5f);
        Educationalscript.GetComponent<Educational>().QuestionPanels[1].SetActive(false);
        // QuestionPanels[0].SetActive(false);
        yield return new WaitForSeconds(.5f);
        losemassg.SetActive(true);

        //  masgg.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        //  Destroy(masgg.gameObject);
        losemassg.SetActive(false);
        Educationalscript.GetComponent<Educational>().Exit();


    }
   

}
