using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryPuzzle : UEPuzzleCanvas
{

    public bool Clickable;
    public List<GameObject> allSymbols;
    public List<GameObject> SelectedSymbols;
    public GameObject Library;
    public GameObject InfoBall;
    public GameObject parent;
    public GameObject Note;

    private Animator LibraryAnim;
    private int CurrentWinValue;
    private Vector2Int GridSize;
    private int WinVal;
    private MemorySymbol Symbol_1;
    private MemorySymbol Symbol_2;
    public  GameObject openpuzzlescript;
    public Animator imageanime;
    public GameObject images;
   
    void Start()
    {
        //images.SetActive(false);
        ShufflePieces();
        SelectedSymbols = new List<GameObject>();
        Clickable = true;
        CurrentWinValue = 0;
        GridSize= new Vector2Int(4, 4);
        WinVal = GetWinValue();
        LibraryAnim = Library.GetComponent<Animator>();
       
    }
    private void Update()
    {

        //if (this.GetComponent<MemoryPuzzle>().isActiveAndEnabled)
        //{

        //    StartCoroutine(imageanimation());

        //}

        if (SelectedSymbols.Count == 1)
            Symbol_1 = SelectedSymbols[0].GetComponent<MemorySymbol>();
        if (SelectedSymbols.Count == 2)
        {
            Clickable = false;
            Symbol_2 = SelectedSymbols[1].GetComponent<MemorySymbol>();
            if(SelectedSymbols[0].tag == SelectedSymbols[1].tag)
            {
                Symbol_1.Solved = true;
                Symbol_2.Solved = true;
                SelectedSymbols.Clear();
                if(SelectedSymbols.Count == 0)
                    Clickable = true;
                CurrentWinValue++;
                if (Win())
                    StartCoroutine(ExitPuzzle());
            }
            else
            {
                StartCoroutine(Hide());
            }
        }
    }
    
    void ShufflePieces()
    { 
        for (int i = 0; i < allSymbols.Count; i++)
        {
            System.Random random = new System.Random();
            int randomNum = random.Next(0, 7);
            int Index = Mathf.Clamp(randomNum * i, 0, 15);
            Vector3 CurrentPosition = allSymbols[i].transform.position;
            allSymbols[i].transform.position = allSymbols[Index].transform.position;
            allSymbols[Index].transform.position = CurrentPosition;
        }
    }
   
    bool IsClear()
    {
        return SelectedSymbols.Count == 0;
    }
    
    bool IsHidden()
    {
        return Symbol_1.Hide && Symbol_2.Hide;
    }
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(0.5f);
        SelectedSymbols.Clear();
        if (SelectedSymbols.Count == 0)
        {
            Symbol_1.Hide = true;
            Symbol_2.Hide = true;
        }
            if(IsHidden())
                Clickable = true;

    }
   
    int GetWinValue()
    {
        return GridSize.x * GridSize.y / 2;
    }

    bool Win()
    {
        return CurrentWinValue == WinVal;
    }
    public void OnClickImage(GameObject img)
    {

        MemorySymbol symbol = img.GetComponent<MemorySymbol>();
        
        if (Clickable && symbol.Hide && !symbol.Solved)
        {
            symbol.Hide = false;
            SelectedSymbols.Add(img);
           
        }
    }
    IEnumerator ExitPuzzle()
    {
        yield return new WaitForSeconds(0.5f);
        UEpuzzlesCanvas.enabled = false;
        Destroy(PuzzlesPanels[2]);
        LibraryAnim.SetBool("memory", true);
        InfoBall.SetActive(true);
        Note.SetActive(true);
        parent.GetComponent<UEPuzzleCanvas>().puzzlecanvasState = false;
        Destroy( openpuzzlescript.GetComponent<openpuzzle>().outline);
        openpuzzlescript.GetComponent<openpuzzle>().enabled = false;

    }
    IEnumerator imageanimation()
    {
        imageanime.SetBool("show", true);
        yield return new WaitForSeconds(5f);
        images.SetActive(true);
        yield return new WaitForSeconds(1f);
        images.GetComponent<Animator>().SetBool("show", true);
       // imageanime.gameObject.SetActive(false);

    }
}
