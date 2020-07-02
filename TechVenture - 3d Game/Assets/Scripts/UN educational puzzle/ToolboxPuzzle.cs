using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ToolboxPuzzle :UEPuzzleCanvas
{
    public GameObject binaryQuestionball;
    public Animator toolboxanimator;
    public GameObject Inventory;
    InventorySlot InventorySlot;
    public Button[] ICs = new Button[4];
    public int WinValue = 4;
    public int CurrentWin = 0;
    public GameObject IC1;
    public GameObject IC2;
    public GameObject IC3;
    public GameObject IC4;

    public GameObject removedIC1;
    public GameObject removedIC2;
    public GameObject removedIC3;
    public GameObject removedIC4;


    public GameObject toolboxexit;
    public GameObject puzzle;
    private Inventory inventory;
    private ItemID ItemID;
    // Start is called before the first frame update
    void Start()
    {
       
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        ItemID = puzzle.GetComponent<ItemID>();
        foreach (Button btn in ICs)
        {
            btn.image.enabled = false;
            btn.onClick.AddListener(delegate { OnICClick(btn); });
        }
        binaryQuestionball.SetActive(false);
    }

    public void OnICClick(Button btn)
    {
        InventorySlot slot = inventory.SelectedSlot;
       // Debug.Log(slot);
        if (slot != null && slot.item != null)
        {
            if (slot.item.name.ToString() == "IC04(1)" || slot.item.name.ToString() == "IC04(2)" ||
                slot.item.name.ToString() == "IC04(3)" || slot.item.name.ToString() == "IC04(4)")
            {
                Debug.Log(btn.name);
                btn.image.enabled = true;
                CurrentWin++;
                inventory.Remove(slot.item, RemoveICSave(slot.name));
                CheckIC(btn);
            }
        }
        
        if (CurrentWin == WinValue)
            StartCoroutine(ExitPuzzle());
    }
    string RemoveICSave(string name)
    {
        ItemID itemID;
        switch (name)
        {
            case "IC04(1)":
                itemID = removedIC1.GetComponent<ItemID>();
                return itemID.ID;
            case "IC04(2)":
                itemID = removedIC2.GetComponent<ItemID>();
                return itemID.ID;
            case "IC04(3)":
                itemID = removedIC3.GetComponent<ItemID>();
                return itemID.ID;
            case "IC04(4)":
                itemID = removedIC4.GetComponent<ItemID>();
                return itemID.ID;
        }
        return null;
    }
    void CheckIC(Button btn)
    {
        switch (btn.name)
        {
            case "Button":
                IC1.SetActive(true);
                SaveLoadManager.instance.ActiveObjectsIDs.Add(IC1.GetComponent<ItemID>().ID);
                break;
            case "Button(1)":
                IC2.SetActive(true);
                SaveLoadManager.instance.ActiveObjectsIDs.Add(IC2.GetComponent<ItemID>().ID);
                break;
            case "Button(2)":
                IC3.SetActive(true);
                SaveLoadManager.instance.ActiveObjectsIDs.Add(IC3.GetComponent<ItemID>().ID);
                break;
            case "Button(3)":
                IC4.SetActive(true);
                SaveLoadManager.instance.ActiveObjectsIDs.Add(IC4.GetComponent<ItemID>().ID);
                break;
        }
    }

    IEnumerator ExitPuzzle()
    {
        SaveLoadManager.instance.SolvedPuzzlesID.Add(ItemID.ID);
        yield return new WaitForSeconds(.5f);
        UEpuzzlesCanvas.enabled = false;
        Destroy(PuzzlesPanels[1]);
        yield return new WaitForSeconds(0.5f);
        toolboxanimator.SetBool("open", true);
        yield return new WaitForSeconds(2f);
        binaryQuestionball.SetActive(true);
        //binaryQuestionball.GetComponent<SphereCollider>().isTrigger = true;
        toolboxexit.GetComponent<UEPuzzleCanvas>().puzzlecanvasState=false;
        

    }

}
