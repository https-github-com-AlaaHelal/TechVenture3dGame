using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ToolboxPuzzle :UEPuzzleCanvas
{
    public GameObject binaryQuestionball;
    public Animator toolboxanimator;
    //public TextMeshProUGUI t;
    public GameObject Inventory;
    InventorySlot InventorySlot;
    public Button[] ICs = new Button[4];
    public int WinValue = 4;
    public int CurrentWin = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Button btn in ICs)
        {
            btn.image.enabled = false;
            btn.onClick.AddListener(delegate { OnICClick(btn); });
        }
        binaryQuestionball.SetActive(false);
    }

    public void OnICClick(Button btn)
    {
        btn.image.enabled = true;
        CurrentWin++;
        //if (InventorySlot.item.name == "ICO4(1)" || InventorySlot.item.name == "ICO4(2)" || InventorySlot.item.name == "ICO4(3)" || InventorySlot.item.name == "ICO4(4)")
        //{
        //    btn.image.enabled = true;
        //    CurrentWin++;
        //}
        if (CurrentWin == WinValue)
           StartCoroutine(ExitPuzzle());
    }

   
    IEnumerator ExitPuzzle()
    {
        yield return new WaitForSeconds(.5f);
        UEpuzzlesCanvas.enabled = false;
        Destroy(PuzzlesPanels[1]);
        yield return new WaitForSeconds(0.5f);
        toolboxanimator.SetBool("open", true);
        yield return new WaitForSeconds(2f);
        binaryQuestionball.SetActive(true);
        //binaryQuestionball.GetComponent<SphereCollider>().isTrigger = true;
        

    }

}
