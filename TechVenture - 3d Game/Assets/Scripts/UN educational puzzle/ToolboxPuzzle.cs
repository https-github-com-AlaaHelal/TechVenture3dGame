using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolboxPuzzle : MonoBehaviour
{
    public GameObject binaryQuestionball;
    // Start is called before the first frame update
    void Start()
    {
        binaryQuestionball.GetComponent<SphereCollider>().isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
