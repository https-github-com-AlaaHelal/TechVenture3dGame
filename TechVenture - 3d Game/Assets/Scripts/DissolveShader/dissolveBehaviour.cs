using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolveBehaviour : MonoBehaviour
{
    //public Material dissolveMat;
    //public float dissolveSpeed = 0.02f;
    //float dissolveAmount = -1;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    dissolveMat.SetFloat("Vector1_D7B00FB3", dissolveAmount);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if(dissolveAmount < 1)
    //    { 
    //        dissolveAmount += dissolveSpeed * Time.deltaTime;
    //        dissolveMat.SetFloat("Vector1_D7B00FB3", dissolveAmount);
    //        Debug.Log(dissolveAmount);
    //    }
    //}
    public float DissolveSpeed;
    [HideInInspector]
    public bool Fall = false;
    public Material DissolveMat;


    private float DissolveAmount = -1;
    private bool DissolveShader = false;

    private void Start()
    {
        DissolveMat.SetFloat("Vector1_D7B00FB3", DissolveAmount);
    }

    private void Update()
    {
        if (DissolveAmount < 1 && DissolveShader)
        {
            DissolveAmount += DissolveSpeed * Time.deltaTime;
            DissolveMat.SetFloat("Vector1_D7B00FB3", DissolveAmount);
            //Debug.Log(DissolveAmount);
        }
        if (DissolveAmount > 0.9f)
        {
            Fall = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            DissolveShader = true;
        }
    }
}
