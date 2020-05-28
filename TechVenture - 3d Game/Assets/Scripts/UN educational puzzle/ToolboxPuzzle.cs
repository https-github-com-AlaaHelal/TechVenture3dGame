using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ToolboxPuzzle :UEPuzzleCanvas
{
    public GameObject binaryQuestionball;
    public Animator toolboxanimator;
    public TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        binaryQuestionball.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void truee()
    {
        t.text = "TRUE";
        StartCoroutine(DestroyQuestion());
    }
    IEnumerator DestroyQuestion()
    {
        yield return new WaitForSeconds(.5f);
      //UEpuzzlesCanvas.enabled = false;
        Destroy(PuzzlesPanels[1]);
        yield return new WaitForSeconds(0.5f);
        toolboxanimator.SetBool("open", true);
        yield return new WaitForSeconds(2f);
        // binaryQuestionball.GetComponent<SphereCollider>().isTrigger = true;
        binaryQuestionball.SetActive(true);

    }

}
