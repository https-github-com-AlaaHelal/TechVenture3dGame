using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UEPuzzleCanvas : MonoBehaviour
{
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
    public GameObject[] PuzzlesPanels = new GameObject[10];
    public Transform PlayerPosition;
    int NumberofPuzzle;
    int layermask = 1 << 11;


    // Start is called before the first frame update
    void Start()
    {
        UEpuzzlesCanvas.enabled = false;

        for (int i = 0; i < 10; i++)
        {
            PuzzlesPanels[i].SetActive(false);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 20, layermask))
        {
            var selection = hit.transform;

            Debug.Log(selection);
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F))
            {
                if (selection.CompareTag("lockerpuzzle"))
                {
                    NumberofPuzzle = 0;
                    Display(NumberofPuzzle);

                }
                if (selection.CompareTag("toolboxpuzzle"))
                {
                    NumberofPuzzle = 1;
                    Display(NumberofPuzzle);

                }

            }
            
            
        }


    }
    void Display(int number)
    {

        UEpuzzlesCanvas.enabled = true;
        PuzzlesPanels[number].SetActive(true);
       
    }
    public void Exit()
    {
        UEpuzzlesCanvas.enabled = false;

        for (int i = 0; i < 10; i++)
        {
            PuzzlesPanels[i].SetActive(false);

        }
    }
}
