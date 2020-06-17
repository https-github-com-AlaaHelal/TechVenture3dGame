using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImage : MonoBehaviour
{
    public GameObject InventoryManager;
    public GameObject Panel;
    public GameObject Canvas;
   
    public Sprite ItemSprite;
    public int puzzlenumber;

    bool exit;

    Inventory Inventory;
    InventorySlot Slot;

    // Start is called before the first frame update
    void Start()
    {
        Inventory = InventoryManager.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        Slot = Inventory.SelectedSlot;
        if(Slot != null && Slot.item != null)
        {
            if(Slot.item.name == ItemSprite.name)
            {
                Debug.Log("Item");
                Canvas.SetActive(true);
                Panel.GetComponent<Image>().sprite = ItemSprite;
            }
        }
        if (exit)
            Canvas.SetActive(false);
    }

    public void Exit()
    {
        exit = true;
    }
}
