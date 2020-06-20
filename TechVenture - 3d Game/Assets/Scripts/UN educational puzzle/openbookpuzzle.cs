using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openbookpuzzle : MonoBehaviour
{
    public Transform player;
    public GameObject PuzzleScript;
    public float Distance=5;
  
   
    // Start is called before the first frame update
    void Start()
    {
        PuzzleScript.SetActive(false);
        PuzzleScript.GetComponent<books>().outlines.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = (this.transform.position - player.position).normalized;
        float direction = Vector3.Dot(player.forward.normalized, transform.forward.normalized);
        float distance = Vector3.Distance(player.position, this.transform.position);
        if (direction >= 0.9 && distance <= Distance) 
        {
            PuzzleScript.GetComponent<books>().outlines.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PuzzleScript.GetComponent<books>().playeranimatore.gameObject.SetActive(true);
                PuzzleScript.GetComponent<books>().camerascript.GetComponent<camera>().enabled = true;
                PuzzleScript.SetActive(false);

            }

            if (Input.GetKeyDown(KeyCode.E)) 
            {
                if (PuzzleScript.GetComponent<books>().solved == false)
                {
                    PuzzleScript.GetComponent<books>().camerascript.GetComponent<camera>().enabled = false;
                    Camera.main.transform.position = PuzzleScript.GetComponent<books>().cameraview.position;
                    Camera.main.transform.rotation = PuzzleScript.GetComponent<books>().cameraview.rotation;
                    PuzzleScript.SetActive(true);
                 
                }
                if (PuzzleScript.GetComponent<books>().solved == true)
                {
                    PuzzleScript.SetActive(false);
                }
            }

           
        }
        else
        {
            PuzzleScript.GetComponent<books>().outlines.SetActive(false);

        }
    }



}
