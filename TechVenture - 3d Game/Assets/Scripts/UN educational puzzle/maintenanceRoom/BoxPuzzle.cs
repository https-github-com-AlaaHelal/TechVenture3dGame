using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxPuzzle : UEPuzzleCanvas
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

    public GameObject puzzle;
    public GameObject ifInformationball;
    public GameObject screwdriver;
    public GameObject canvasExit;
    public GameObject Outline;
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
        istrue = false;
        screwdriver.SetActive(false);
        ifInformationball.SetActive(false);
    }


    IEnumerator exit()
    {
        istrue = true;
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1.5f);
        Destroy(Outline);
        //UEpuzzlesCanvas.enabled = false;
        //Debug.Log(PuzzlesPanels.Length);
        Destroy(puzzle);
        yield return new WaitForSeconds(.5f);
        boxAnimator.SetBool("Open", true);
        yield return new WaitForSeconds(.5f);
        //  binaryInformationball.GetComponent<SphereCollider>().isTrigger = true;
        ifInformationball.SetActive(true);
        screwdriver.SetActive(true);
        // Time.timeScale = 1f;
        canvasExit.GetComponent<UEPuzzleCanvas>().puzzlecanvasState = false;


    }
    bool Win()
    {
        return n1 == 4 & n2 == 7 & n3 == 9 & n4 == 5;

    }
    public void ChangeButton1()
    {
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
