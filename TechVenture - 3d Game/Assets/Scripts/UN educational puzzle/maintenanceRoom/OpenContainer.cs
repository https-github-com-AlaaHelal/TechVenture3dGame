using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenContainer : MonoBehaviour
{
    public GameObject Outline;
    public GameObject Holder;
    public GameObject Camera;
    public int PuzzleNumber;
    public GameObject UEPuzzleCanvas;

    bool ContainerActive;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Outline.SetActive(true);
            if (ContainerActive && Input.GetKeyDown(KeyCode.E))
            {
                Camera.GetComponent<camera>().enabled = false;

                Camera.transform.position = Holder.transform.position;
                Camera.transform.rotation = Holder.transform.rotation;

                UEPuzzleCanvas.GetComponent<UEPuzzleCanvas>().NumberofPuzzle = PuzzleNumber;
                UEPuzzleCanvas.GetComponent<UEPuzzleCanvas>().Display(PuzzleNumber);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Camera.GetComponent<camera>().enabled = true;

        Outline.SetActive(false);
    }
}
