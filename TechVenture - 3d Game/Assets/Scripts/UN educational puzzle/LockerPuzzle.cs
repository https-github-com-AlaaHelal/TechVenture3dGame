﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class LockerPuzzle : UEPuzzleCanvas
{
    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public TextMeshProUGUI Text3;
    public TextMeshProUGUI Text4;
    public bool istrue;
    public Animator lockeranimator;
    public Canvas puzzle;
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Sprite trueimg;
    public GameObject binaryInformationball;



    [SerializeField ]
    int n1;
    [SerializeField]
    int n2;
    [SerializeField]
    int n3;
    [SerializeField]
    int n4;
    




    // Start is called before the first frame update
    void Start()
    {

        binaryInformationball.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(n1 ==2 & n2 == 5 & n3 ==8 & n4 == 0)
        {
            istrue = true;
            b1.image.sprite = trueimg;
            b2.image.sprite = trueimg;
            b3.image.sprite = trueimg;
            b4.image.sprite = trueimg;
            StartCoroutine(exit());


        }

    }
    IEnumerator exit()
    {
        yield return new WaitForSeconds(1.5f);
      //UEpuzzlesCanvas.enabled = false;
        Destroy(PuzzlesPanels[0]);
        yield return new WaitForSeconds(.5f);
        lockeranimator.SetBool("open", true);
        yield return new WaitForSeconds(1.5f);
        //  binaryInformationball.GetComponent<SphereCollider>().isTrigger = true;
        binaryInformationball.SetActive(true);


    }
    public void ChangeButton1()
    {
       
        if (istrue == false)
        {
            n1++;

            if (n1 > 9)
            {
                n1 = 0;
            }
            Text1.text = "" + n1;
        }
        
    }
    public void ChangeButton2()
    { if (istrue == false)
        {
            n2++;

            if (n2 > 9)
            {
                n2 = 0;
            }
            Text2.text = "" + n2;
        }
       
    }
    public void ChangeButton3()
    {  if (istrue == false)
        {
            n3++;

            if (n3 > 9)
            {
                n3 = 0;
            }
            Text3.text = "" + n3;
        }
        
    }
    public void ChangeButton4()
    { if (istrue == false)
        {
            n4++;

            if (n4 > 9)
            {
                n4 = 0;
            }
            Text4.text = "" + n4;
        }
       
    }
}
