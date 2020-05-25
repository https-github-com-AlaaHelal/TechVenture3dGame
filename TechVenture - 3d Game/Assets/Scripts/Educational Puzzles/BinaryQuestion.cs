using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BinaryQuestion : Educational
{
    // Start is called before the first frame update
    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public TextMeshProUGUI Text3;
    public TextMeshProUGUI Text4;
    public TextMeshProUGUI Text5;

    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;

    public GameObject Card;
    private CardShow cardshow;

    public Sprite trueimg;

    public bool istrue;

    [SerializeField]
    int n1;
    [SerializeField]
    int n2;
    [SerializeField]
    int n3;
    [SerializeField]
    int n4;
    [SerializeField]
    int n5;


   


    // Start is called before the first frame update
    void Start()
    {

        cardshow = Card.GetComponent<CardShow>();

    }

    // Update is called once per frame
    void Update()
    {
        if (n1 == 1 & n2 == 0 & n3 == 1 & n4 == 1 & n5==0 )
        {
           
            istrue = true;
            b1.image.sprite = trueimg;
            b2.image.sprite = trueimg;
            b3.image.sprite = trueimg;
            b4.image.sprite = trueimg;
            b5.image.sprite = trueimg;
            cardshow.showCard = true;
            //FindObjectOfType<ScoreManager>().AddScore();
            StartCoroutine(exit());
           
        }

    }
    IEnumerator exit()
    {
        yield return new WaitForSeconds(1.5f);
        QuestionPanels[0].SetActive(false);
        yield return new WaitForSeconds(.5f);
      masgg.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(masgg.gameObject);






    }
    public void ChangeButton1()
    {

        if (istrue == false)
        {
            n1++;

            if (n1 > 1)
            {
                n1 = 0;
            }
            Text1.text = "" + n1;
        }

    }
    public void ChangeButton2()
    {
        if (istrue == false)
        {
            n2++;

            if (n2 > 1)
            {
                n2 = 0;
            }
            Text2.text = "" + n2;
        }

    }
    public void ChangeButton3()
    {
        if (istrue == false)
        {
            n3++;

            if (n3 > 1)
            {
                n3 = 0;
            }
            Text3.text = "" + n3;
        }

    }
    public void ChangeButton4()
    {
        if (istrue == false)
        {
            n4++;

            if (n4 > 1)
            {
                n4 = 0;
            }
            Text4.text = "" + n4;
        }

    }
    public void ChangeButton5()
    {
        if (istrue == false)
        {
            n5++;

            if (n5 > 1)
            {
                n5 = 0;
            }
            Text5.text = "" + n5;
        }

    }
}
