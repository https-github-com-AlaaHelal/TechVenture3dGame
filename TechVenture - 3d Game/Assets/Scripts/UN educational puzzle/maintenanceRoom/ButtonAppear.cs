using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAppear : MonoBehaviour
{
    private Inventory inventory;
    public Item item;  // Current item in the slot
    public GameObject ScreenClueScript;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        InventorySlot slot = inventory.SelectedSlot;

        if (slot != null && slot.item != null)
        {

            if (slot.item.name.ToString() == "button")
            {
                ScreenClueScript.GetComponent<ScreenClueAppeared>().buttonHand.SetActive(true);
                if (ScreenClueScript.GetComponent<ScreenClueAppeared>().solved == true)
                {
                    inventory.Remove(slot.item);
                }

            }
        }
    }
}
