using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UEPuzzleCanvas : MonoBehaviour
{
    public Canvas UEpuzzlesCanvas;
    public GameObject[] PuzzlesPanels = new GameObject[10];
    public Transform PlayerPosition;
    int NumberofPuzzle;
 


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
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {   
                var selection = hit.transform;
                float Distance = Vector3.Distance(PlayerPosition.position, selection.position);
                float Diriction = PlayerPosition.rotation.y - selection.rotation.y;

                if(  Distance <=11 ) 
                {
                    if (selection.CompareTag("lockerpuzzle"))
                    {
                        NumberofPuzzle = 0; 
                        Display(NumberofPuzzle);
                        Debug.Log(Distance);
                    }
                    if (selection.CompareTag("toolboxpuzzle"))
                    {
                        NumberofPuzzle = 1;
                        Display(NumberofPuzzle);
                        Debug.Log(Distance);
                    }
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
