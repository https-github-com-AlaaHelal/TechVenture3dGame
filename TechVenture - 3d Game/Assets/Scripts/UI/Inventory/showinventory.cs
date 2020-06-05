using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showinventory : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator inventory;
    public bool state;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (state == false)
            {
                inventory.SetBool("show", true);
                state = true;
              
                
            }
            else
            {
                inventory.SetBool("show", false);
                state = false;
               
            }
        }

    }
    public void show()
    {
        if (state == false)
        {
            inventory.SetBool("show", true);
            state = true;
        }
        else
        {
            inventory.SetBool("show", false);
            state = false;
        }
    }
}
