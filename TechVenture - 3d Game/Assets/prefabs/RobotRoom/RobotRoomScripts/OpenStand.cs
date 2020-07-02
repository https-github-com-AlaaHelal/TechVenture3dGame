using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStand : MonoBehaviour
{
    Animator Standanimator;
    GameObject Stand;
    public GameObject FlashMemoryOnStand;
    public GameObject ArrowHintScreen;
    public GameObject Screen;
    public Transform player;
    public float Distance = 7;
    public GameObject Inventory;
    private Inventory inventory;
   // public GameObject PuzzleScreen;
    


    public void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        Stand = GameObject.FindGameObjectWithTag("Stand");
        Standanimator = Stand.GetComponentInParent<Animator>();
        
      
        FlashMemoryOnStand.SetActive(false);
        ArrowHintScreen.SetActive(false);
       
    }
    public void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);

        float direction = Vector3.Dot(player.forward, transform.forward);
        if ( distance <= Distance)
        {

            Debug.Log("Open The Screen");
        }
         if (direction < 0 && distance <= Distance && Input.GetKeyDown(KeyCode.E))
        {

            FindObjectOfType<AddLaserToArm>().TurnOnScreenPuzzle();

        }


        if (distance >= 20)
        {
            Standanimator.SetBool("open", false);
            Standanimator.SetFloat("speed", 1);
           // openStand = false;


        }
        InventorySlot slot = inventory.SelectedSlot;
        if (slot != null && slot.item != null)
        {

            if (slot.item.name.ToString() == "Flash" && distance <= Distance)

            {
             
                //inventory.Remove(slot.item);
                StartCoroutine (OpenScreenHint());
              

            }
        }



    }



    IEnumerator OpenScreenHint()
    {
        FlashMemoryOnStand.SetActive(true);
        yield return new WaitForSeconds(2f);
        ArrowHintScreen.SetActive(true);
        Screen.SetActive(false);
    }
}