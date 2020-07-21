using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UEPuzzleCanvas : MonoBehaviour
{
    public GameObject inventorycanvas;
    public bool puzzlecanvasState;
    private static UEPuzzleCanvas _instance;
    public static UEPuzzleCanvas Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject UNEducationalManager = new GameObject("UnEducationManger");
                UNEducationalManager.GetComponent<UEPuzzleCanvas>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    public Canvas UEpuzzlesCanvas;
    public GameObject[] PuzzlesPanels = new GameObject[3];
    public Transform PlayerPosition;
    public int NumberofPuzzle;
  


    // Start is called before the first frame update
    void Start()
    {
        UEpuzzlesCanvas.enabled = false;

        for (int i = 0; i < PuzzlesPanels.Length; i++)
        {
            PuzzlesPanels[i].SetActive(false);
           
        }
    }

  
   public void Display(int number)
    {

        UEpuzzlesCanvas.enabled = true;
        PuzzlesPanels[number].SetActive(true);
      
        puzzlecanvasState = true;
        //Time.timeScale = 0f;


    }
    public void Exit()
    {
        puzzlecanvasState = false;

        UEpuzzlesCanvas.enabled = false;

        for (int i = 0; i < 3; i++)
        {
            PuzzlesPanels[i].SetActive(false);
           

        }


    }
}
