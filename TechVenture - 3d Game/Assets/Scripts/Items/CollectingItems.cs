using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingItems : MonoBehaviour
{
    public GameObject Player;
    bool nearToItem = false;
    public Item item;

    // Update is called once per frame
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
        bool wasPickedUp = Inventory.instance.Add(item);  // Add to inventory

        if (other.CompareTag("Player"))
        {

            print("press Space");
            nearToItem = true;
        }


        if (wasPickedUp)
        {

            this.gameObject.SetActive(false);
        }
    }
        private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space)) {  }
                //this.gameObject.SetActive(false);
        }
    }


}

