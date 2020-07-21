using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoxPuzzle : MonoBehaviour
{
    
    public GameObject ScrewDriver;
    public GameObject Key;
    public Animator PlayerAnim;

    private Animator BoxAnim;
    private Inventory inventory;
    private InventorySlot slot;
    private bool solved = false;
    private bool Selected = false;

    private void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        BoxAnim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        slot = inventory.SelectedSlot;

        if (slot != null && slot.item != null)
        {

            if (slot.item.name.ToString() == "screwdriver")
            {
                if(!solved)
                  ScrewDriver.SetActive(true);
                Selected = true;
                if (solved)
                {
                    inventory.Remove(slot.item);
                }

            }

        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            float direction = Vector3.Dot(other.transform.forward, transform.right);
            if (Input.GetKeyDown(KeyCode.E) && Selected && direction > 0)
            {
                StartCoroutine(Solve());
            }
        }
    }

    IEnumerator Solve()
    {
        Key.SetActive(true);
        PlayerAnim.SetBool("pickup", true);
        PlayerAnim.SetBool("pickupmid", true);
        yield return new WaitForSeconds(0.5f);
        //PlayerAnim.SetBool("pickupmid", false);
        //yield return new WaitForSeconds(0.2f);
        //PlayerAnim.SetBool("pickupmid", true);
        BoxAnim.SetBool("open", true);
        PlayerAnim.SetBool("pickupmid", false);
        PlayerAnim.SetBool("pickup", false);
        yield return new WaitForSeconds(0.5f);
        solved = true;
        ScrewDriver.SetActive(false);
    }
}
