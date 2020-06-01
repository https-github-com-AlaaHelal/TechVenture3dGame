using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockers : MonoBehaviour
{
    // Start is called before the first frame update
    int layermask = 1 << 11;
    Animator lockeranimator;
    void Start()
    {
        lockeranimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10, layermask))
        {
           var selection = hit.transform;

            Debug.Log(selection);

            if (selection == this.transform)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F))
                {
                    lockeranimator.SetBool("open", true);
                        
                }
            }
        }
    }
}
