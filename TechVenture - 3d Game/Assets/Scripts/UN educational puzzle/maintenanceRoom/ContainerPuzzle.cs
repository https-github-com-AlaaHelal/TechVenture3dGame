using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPuzzle : MonoBehaviour
{
    Animator KeyAnimator;
    public Transform HiddenContainerKey;
    public GameObject HiddenContainerKey1;
    public GameObject Inventory;
    private Inventory inventory;
    public Transform player;
    public float Distance = 9;
    //   public float Distance1 = 4;
    public Animator playeranimatore;
    public GameObject Container;
    //  public GameObject HiddeContainerr;
    bool StartRotatingTheKey;
    public float TurnSpeed = 100f;
    public int[] Pattern = { 1, 1, -1, -1, 1, -1, 1 };
   
    public int[] InputArray;
    public GameObject tablet;
   public int j;
   public int i;
    int count;
   



    void Start()
    {
        // Pattern =[1,1,-1,-1,1,-1,1]};
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        HiddenContainerKey1.SetActive(false);
        KeyAnimator = Container.GetComponent<Animator>();



    }
    public void Update()
    {


        float distance = Vector3.Distance(player.position, transform.position);

        InventorySlot slot = inventory.SelectedSlot;

        // Debug.Log(slot);
        if (slot != null && slot.item != null)
        {

            if (slot.item.name.ToString() == "containerKey" && distance <= Distance)

            {
                // Debug.Log(distance);
                HiddenContainerKey1.SetActive(true);
                inventory.Remove(slot.item);

                StartRotatingTheKey = true;
            }
        }



            if (StartRotatingTheKey == true && distance <= Distance && Input.GetKeyDown(KeyCode.RightArrow))
            {
            HiddenContainerKey.Rotate(Vector3.up, TurnSpeed * Time.deltaTime);
            InputArray[i] = 1;
            Win();
            i++;
            j++;
            Debug.Log("countRight");



            }
            else if (StartRotatingTheKey == true && distance <= Distance && Input.GetKeyDown(KeyCode.LeftArrow))
            {
            HiddenContainerKey.Rotate(Vector3.up, -TurnSpeed * Time.deltaTime);
               
            InputArray[i] = -1;
            Win();
            i++;
            j++;

            }




    }


    public void Win()


    {   if (InputArray[i] == Pattern[j])
            {
                count++;
                if (count == 6)
                {
                KeyAnimator.SetBool("open", true);
                tablet.SetActive(true);
                }
        }
   

    }





}
