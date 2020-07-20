using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{

  
    private Inventory inventory;
    GameObject Inventory;
    InventorySlot InventorySlot;
    public Item item;  // Current item in the slot
    public GameObject labtopscript;
    public GameObject removedFlash;

    public void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
       


    }

    public void Update()
    {
        InventorySlot slot = inventory.SelectedSlot;

        if (slot != null && slot.item != null)
        {
           
            if (slot.item.name.ToString() == "flashmemory")
            {
                Debug.Log("1");
                labtopscript.GetComponent<openlabtop>().flash.SetActive(true);
                if (labtopscript.GetComponent<openlabtop>().solved==true)
                {
                    inventory.Remove(slot.item);
                    Debug.Log("2");
                }

            }
        }


    }
}

        



