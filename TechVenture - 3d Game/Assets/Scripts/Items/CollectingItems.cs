using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingItems : MonoBehaviour
{
    public GameObject Player;
    bool nearToItem = false;
    public int LayerMask = 1 << 11;
    public Item item;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 20, LayerMask))
            {
                Debug.Log(hit.collider.name);
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

        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            //    gameObject.SetActive(false);
            //    bool wasPickedUp = Inventory.instance.Add(item);  // Add to inventory

            //}
            if (Input.GetKeyDown(KeyCode.F))
            {
                gameObject.SetActive(false);
                bool wasPickedUp = Inventory.instance.Add(item);
            }
        }
    }


}

