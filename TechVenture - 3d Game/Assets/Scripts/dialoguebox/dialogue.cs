using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue : Interactable
{
    public string Aname;
    public string[] Dialogue;
    public override void Interact()
    {
        dialoguesystem.Instance.AddNewDialogue(Dialogue , Aname);
      
    }
}
