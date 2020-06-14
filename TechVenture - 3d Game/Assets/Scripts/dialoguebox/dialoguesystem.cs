using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialoguesystem : MonoBehaviour
{
    public static dialoguesystem Instance { get; set; }
    public GameObject dialoguepanal;
    public string namea;
    public string dialoguelines;
    TextMeshProUGUI dialogueText , nameTaxt;
    void Awake()
    {   dialogueText = dialoguepanal.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        nameTaxt = dialoguepanal.transform.Find("name").GetChild(0).GetComponent<TextMeshProUGUI>();
        dialoguepanal.SetActive(false);
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void AddNewDialogue(string lines , string name )
    {
        this.dialoguelines = lines;
        this.namea = name ;
        creatdialogue();
    }
    public void creatdialogue()
    {
        dialogueText.text = dialoguelines;
        nameTaxt.text = namea;
        dialoguepanal.SetActive(true);
    }
    public void Enddialogue()
    {
        dialoguepanal.SetActive(false);
    }
}