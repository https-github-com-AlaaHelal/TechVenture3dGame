using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNumPuzzle : MonoBehaviour
{
    //public int PuzzleNumber;
    //public GameObject UEpuzzle;
    public Canvas NumPad;
    public Animator LaserStandAnim;
    public GameObject LoopQuestion;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log(UEpuzzle.GetComponent<UEPuzzleCanvas>().PuzzlesPanels.Length);

            //UEpuzzle.GetComponent<UEPuzzleCanvas>().NumberofPuzzle = PuzzleNumber;
            //UEpuzzle.GetComponent<UEPuzzleCanvas>().Display(PuzzleNumber);
            NumPad.enabled = true;
        }
    }
    public void Solved()
    {
        NumPad.enabled = false;
        LaserStandAnim.SetBool("open", true);
        LoopQuestion.GetComponent<SphereCollider>().isTrigger = true;
    }
    public void Exit()
    {
        NumPad.GetComponent<NumpadPuzzle>().Input = "";
        NumPad.enabled = false;
    }
}
