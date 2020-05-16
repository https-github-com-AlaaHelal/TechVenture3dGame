using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolveBehaviour : MonoBehaviour
{ 
    public Material dissolveMat;
    public float dissolveSpeed = 0.02f;
    float dissolveAmount = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        dissolveMat.SetFloat("Vector1_D7B00FB3", dissolveAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if(dissolveAmount < 1)
        { 
            dissolveAmount += dissolveSpeed * Time.deltaTime;
            dissolveMat.SetFloat("Vector1_D7B00FB3", dissolveAmount);
            Debug.Log(dissolveAmount);
        }
    }
}
