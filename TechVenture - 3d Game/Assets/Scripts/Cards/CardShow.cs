using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShow : MonoBehaviour
{
    public GameObject KeyCard;
    [HideInInspector]
    public bool hasKeyCard = false;
    public bool showCard = false;
    public int instantiate = 0;
    public float upValue = 2f;
    public float forwardValue = 3f;
    public float xRotation = -13f;
    public float yRotation = -32f;
    public float zRotation = 42f;

    private Transform Character;
    
    private GameObject card;
  
    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    showCard = true;
        //    hasKeyCard = true;
        //    Debug.Log(showCard);
        //}
        if (showCard)
        {
            instantiate++;
            showCard = false;
        }
        if (instantiate == 1)
        {
            Vector3 position = new Vector3(Character.position.x, Character.position.y + upValue, Character.position.z + forwardValue);
            Quaternion rotation = Quaternion.Euler(27f, 0, -68f);
            card = Instantiate(KeyCard, position, rotation) as GameObject;
        }
        if(card != null)
        {
            card.transform.Rotate(new Vector3(100f, 0f, 0f) * Time.deltaTime);
        }
        
    }
}
