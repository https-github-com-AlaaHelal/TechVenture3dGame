using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafePuzzle : MonoBehaviour
{
    public Animator playeranimatore;
    public Transform player;
    public float Distance = 7;
    public GameObject SafeCanvas;
    public GameObject camerascript;
    public Transform cameraview;
 
   public GameObject Safe;
     Animator SafeAnimator;



    public Text Text1;
    public Text Text2;
    public Text Text3;
    public Text Text4;
    public Text Text5;
    public Text Text6;
    public bool istrue;

    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;
    public Button b6;
  
    public GameObject Safeexit;


    [SerializeField]
    int n1 = 0;
    [SerializeField]
    int n2 = 0;
    [SerializeField]
    int n3 = 0;
    [SerializeField]
    int n4 = 0;
    [SerializeField]
    int n5 = 0;
    [SerializeField]
    int n6 = 0;
    bool open;

    private void Start()
    {
       // Safe = GameObject.FindGameObjectWithTag("SAFE");
        SafeAnimator = Safe.GetComponentInParent<Animator>();

        SafeCanvas.SetActive(false);
    }

    void Update()
    {
        float direction = Vector3.Dot(player.forward, transform.forward);
        float distance = Vector3.Distance(player.position, transform.position);


       //Debug.Log(distance);
        if (direction < 0  && Input.GetKeyDown(KeyCode. E) && distance <= Distance)
        {      SafeCanvas.SetActive(true);
            camerascript.GetComponent<camera>().enabled = false;
            Camera.main.transform.position = cameraview.position;
            Camera.main.transform.rotation = cameraview.rotation;
            playeranimatore.gameObject.SetActive(false);

        }


        if (open == true && distance >= 40)
        {
            SafeAnimator.SetBool("open", false);
            SafeAnimator.SetFloat("speed", 2);

        }
    }


    IEnumerator exit()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1.5f);

        Destroy(SafeCanvas);
        camerascript.GetComponent<camera>().enabled = true;
        playeranimatore.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        SafeAnimator.SetBool("open", true);
        SafeAnimator.SetFloat("speed", 2);
        open = true;
      //  yield return new WaitForSeconds(.5f);
       // Safeexit.GetComponent<UEPuzzleCanvas>().puzzlecanvasState = false;


    }
    bool Win()
    {
        return n1 == 7 & n2 == 8 & n3 == 1 & n4 == 4 & n5== 6 & n6 == 0;

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
            b1.enabled = false;
            b2.enabled = false;
            b3.enabled = false;
            b4.enabled = false;
            b5.enabled = false;
            b6.enabled = false;

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
            b1.enabled = false;
            b2.enabled = false;
            b3.enabled = false;
            b4.enabled = false;
            b5.enabled = false;
            b6.enabled = false;
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
            b1.enabled = false;
            b2.enabled = false;
            b3.enabled = false;
            b4.enabled = false;
            b5.enabled = false;
            b6.enabled = false;
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
            b1.enabled = false;
            b2.enabled = false;
            b3.enabled = false;
            b4.enabled = false;
            b5.enabled = false;
            b6.enabled = false;
            StartCoroutine(exit());
        }
    }

    public void ChangeButton5()
    {
        if (!Win())
        {
            n5++;

            if (n5 > 9)
            {
                n5 = 0;
            }
            Text5.text = "" + n5;
        }
        if (Win())
        {
            b1.enabled = false;
            b2.enabled = false;
            b3.enabled = false;
            b4.enabled = false;
            b5.enabled = false;
            b6.enabled = false;
            StartCoroutine(exit());
        }

    }
    public void ChangeButton6()
    {
        if (!Win())
        {
            n6++;

            if (n6 > 9)
            {
                n6 = 0;
            }
            Text6.text = "" + n6;
        }
        if (Win())
        {
            b1.enabled = false;
            b2.enabled = false;
            b3.enabled = false;
            b4.enabled = false;
            b5.enabled = false;
            b6.enabled = false;
            StartCoroutine(exit());
        }





    }
}

















