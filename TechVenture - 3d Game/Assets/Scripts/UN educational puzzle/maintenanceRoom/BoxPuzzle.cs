using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxPuzzle : MonoBehaviour
{
    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public TextMeshProUGUI Text3;
    public TextMeshProUGUI Text4;

    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;

    public Animator boxAnimator;
    public bool istrue;

    public Canvas puzzle;
    public GameObject ifInformationball;
    public GameObject screwdriver;
    public GameObject canvasExit;
    public Sprite trueimg;

    [SerializeField]
    int n1 = 0;
    [SerializeField]
    int n2 = 0;
    [SerializeField]
    int n3 = 0;
    [SerializeField]
    int n4 = 0;


    // Start is called before the first frame update
    void Start()
    {
        screwdriver.SetActive(false);
        ifInformationball.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator exit()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1.5f);
        //UEpuzzlesCanvas.enabled = false;
        //Destroy(PuzzlesPanels[0]);
        yield return new WaitForSeconds(.5f);
        boxAnimator.SetBool("open", true);
        boxAnimator.SetFloat("speed", 2);
        yield return new WaitForSeconds(.5f);
        //  binaryInformationball.GetComponent<SphereCollider>().isTrigger = true;
        ifInformationball.SetActive(true);
        screwdriver.SetActive(true);
        // Time.timeScale = 1f;
        canvasExit.GetComponent<UEPuzzleCanvas>().puzzlecanvasState = false;


    }
    bool Win()
    {
        return n1 == 2 & n2 == 5 & n3 == 8 & n4 == 4;

    }
    public void ChangeButton1()
    {

        //if (istrue == false)
        //{
        //    n1++;

        //    if (n1 > 9)
        //    {
        //        n1 = 0;
        //    }
        //    Text1.text = "" + n1;
        //}

        if (!Win())
        {
            n1++;

            if (n1 > 9)
            {
                n1 = 0;
            }
            Text1.text = "" + n1;
        }
        if (Win())
        {
            b1.image.sprite = trueimg;
            b2.image.sprite = trueimg;
            b3.image.sprite = trueimg;
            b4.image.sprite = trueimg;
            StartCoroutine(exit());
        }

    }
    public void ChangeButton2()
    {
        //if (istrue == false)
        //    {
        //        n2++;

        //        if (n2 > 9)
        //        {
        //            n2 = 0;
        //        }
        //        Text2.text = "" + n2;
        //    }
        if (!Win())
        {
            n2++;

            if (n2 > 9)
            {
                n2 = 0;
            }
            Text2.text = "" + n2;
        }
        if (Win())
        {
            b1.image.sprite = trueimg;
            b2.image.sprite = trueimg;
            b3.image.sprite = trueimg;
            b4.image.sprite = trueimg;
            StartCoroutine(exit());
        }

    }
    public void ChangeButton3()
    {
        //if (istrue == false)
        //{
        //    n3++;

        //    if (n3 > 9)
        //    {
        //        n3 = 0;
        //    }
        //    Text3.text = "" + n3;
        //}
        if (!Win())
        {
            n3++;

            if (n3 > 9)
            {
                n3 = 0;
            }
            Text3.text = "" + n3;
        }
        if (Win())
        {
            b1.image.sprite = trueimg;
            b2.image.sprite = trueimg;
            b3.image.sprite = trueimg;
            b4.image.sprite = trueimg;
            StartCoroutine(exit());
        }

    }
    public void ChangeButton4()
    {
        //if (istrue == false)
        //{
        //    n4++;

        //    if (n4 > 9)
        //    {
        //        n4 = 0;
        //    }
        //    Text4.text = "" + n4;
        //}
        if (!Win())
        {
            n4++;

            if (n4 > 9)
            {
                n4 = 0;
            }
            Text4.text = "" + n4;
        }
        if (Win())
        {
            b1.image.sprite = trueimg;
            b2.image.sprite = trueimg;
            b3.image.sprite = trueimg;
            b4.image.sprite = trueimg;
            StartCoroutine(exit());
        }

    }
}
