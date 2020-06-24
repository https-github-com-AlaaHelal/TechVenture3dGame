using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakGlass : MonoBehaviour
{
    public GameObject DestoryedGlass;
  

    void Update()
    {
        
    }



    public void Explode()
    {
        Instantiate(DestoryedGlass, transform.position, transform.rotation);
        Destroy(gameObject);


    }





  

}
