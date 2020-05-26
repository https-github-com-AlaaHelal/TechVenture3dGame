using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingWeapons : MonoBehaviour
{

    public GameObject Player;
    bool nearToItem = false;
    public Image image;
    // Update is called once per frame

    public void Start()
    {
        image.enabled=false;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform)
                {
                    if (!nearToItem)
                        print("Get Closer");
                }

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            print("press Space");
            nearToItem = true;

            gameObject.SetActive(false);
            image.enabled=true;
            
        }

    }
}
