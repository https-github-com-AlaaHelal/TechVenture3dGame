using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShow : MonoBehaviour
{
    public GameObject KeyCard;
    public float upValue = 2f;
    public float forwardValue = 20f;
    public float rightValue = -2f;
    public float UpValue = 3;
    private Transform Character;
    
    private GameObject Card1;
    public GameObject Card2;

    public static CardShow instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject);
        Character = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    public void ShowCard(string QuestionBall)
    {
        if(QuestionBall.Equals("Binary"))
        {
            Vector3 position = new Vector3(Character.position.x + rightValue, Character.position.y + upValue, Character.position.z - forwardValue);
            Quaternion rotation = Quaternion.Euler(14, 16, 10);
            Card1 = Instantiate(KeyCard, position, rotation) as GameObject;
            Card2 = Instantiate(KeyCard) as GameObject;
        }
        else
        {
            Card2 = Instantiate(KeyCard);
        }
        Card2.GetComponent<BoxCollider>().isTrigger = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Card1!= null)
        {
            Card1.transform.Rotate(new Vector3(50, 0, 0f) * Time.deltaTime);
        }
        if(Card2 != null)
        {
            Card2.transform.Rotate(new Vector3(50,0, 0) * Time.deltaTime);
        }
    }
}
