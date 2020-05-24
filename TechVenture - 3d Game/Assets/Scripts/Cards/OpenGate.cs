using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject keyCard;
    public GameObject gate;


    private Animator GateAnim;
    private CardShow CardShow;
    // Start is called before the first frame update
    void Start()
    {
        GateAnim = gate.GetComponent<Animator>();
        CardShow = keyCard.GetComponent<CardShow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GateAnim.SetBool("openGate", true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Card" && CardShow.hasKeyCard)
        {
            GateAnim.SetBool("openGate", true);
        }
    }
}
