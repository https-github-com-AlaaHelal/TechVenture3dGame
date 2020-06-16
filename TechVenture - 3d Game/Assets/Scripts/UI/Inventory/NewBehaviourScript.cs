using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{

    public GameObject flashmemory;
    private Inventory inventory;
    GameObject Inventory;
    InventorySlot InventorySlot;
    //public Item item;  // Current item in the slot


    public void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        flashmemory.SetActive(false);


    }

    public void Update()
    {
        InventorySlot slot = inventory.SelectedSlot;
       
        if (slot != null && slot.item != null)
        {
            Debug.Log("flash1");
            if (slot.item.name.ToString()== "flashmemory")
            {
                flashmemory.SetActive(true);
                Debug.Log("flash2");
            }
        }

    
    }
}

        



