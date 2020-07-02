using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowingPaper : MonoBehaviour
{
    public GameObject Inventory;
    private Inventory inventory;
    public GameObject paperCanvas;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        paperCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InventorySlot slot = inventory.SelectedSlot;
        if (slot != null && slot.item != null)
        {

            if (slot.item.name.ToString() == "Paper")

            {

                //inventory.Remove(slot.item);
                paperCanvas.SetActive(true);


            }
        }

    }



    public void exit()

    {
        Destroy(paperCanvas);
    }

}
