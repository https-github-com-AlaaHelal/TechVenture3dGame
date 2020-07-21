using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoxPuzzle : MonoBehaviour
{
    public GameObject Outline;
    public int PuzzleNumber;
    public GameObject UEPuzzleCanvas;
    public GameObject Boxpuzzle;

    private void OnTriggerStay(Collider other)
    {
        if (!Boxpuzzle.GetComponent<BoxPuzzle>().istrue)
        {
            Outline.SetActive(true);
            if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
                UEPuzzleCanvas.GetComponent<UEPuzzleCanvas>().NumberofPuzzle = PuzzleNumber;
                UEPuzzleCanvas.GetComponent<UEPuzzleCanvas>().Display(PuzzleNumber);
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (Outline != null)
        {
            Outline.SetActive(false);
        }
    }
}
