using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public virtual void Interact()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))

                this.gameObject.SetActive(false);
            Interact();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        dialoguesystem.Instance.Enddialogue();
    }
}

