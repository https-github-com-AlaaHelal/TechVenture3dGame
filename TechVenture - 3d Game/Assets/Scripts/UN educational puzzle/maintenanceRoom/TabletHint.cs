using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletHint : UEPuzzleCanvas
{
    public int puzzleNumber;
    public GameObject UEpuzzle;
    public GameObject tabletCanvas;

    private InventorySlot slot;
    

    // Update is called once per frame
    void Update()
    {
        slot = Inventory.instance.SelectedSlot;
        if(slot != null && slot.item != null)
        {
            if(slot.item.name == "tablet")
            {
                UEpuzzle.GetComponent<UEPuzzleCanvas>().NumberofPuzzle = puzzleNumber;
                UEpuzzle.GetComponent<UEPuzzleCanvas>().Display(puzzleNumber);
            }
        }
    }
    void ExitCanvas()
    {
        tabletCanvas.SetActive(false);
    }
}
