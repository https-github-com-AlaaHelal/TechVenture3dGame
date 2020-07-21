using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePuzzle : MonoBehaviour
{
    public GameObject ContainerPart;
    public GameObject Key;
    public Animator PlayerAnim;

    private Inventory inventory;
    private InventorySlot slot;
    private bool Solved = false;
    private bool Selected = false;
    private Animator tableAnim;

    // Start is called before the first frame update
    void Start()
    {
        inventory = inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        tableAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slot = inventory.SelectedSlot;

        if (slot != null && slot.item != null && !Solved)
        {
            if (slot.item.name.ToString() == "tableKey")
            {
                if (!Solved)
                {
                    Key.SetActive(true);
                    Selected = true;
                }
                else
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
            if(Input.GetKeyDown(KeyCode.E) && Selected && !Solved)
            {
                StartCoroutine(Solve());
            }
        }
    }
    IEnumerator Solve()
    {
       
        PlayerAnim.SetBool("pickup", true);
        PlayerAnim.SetBool("pickupmid", true);
        yield return new WaitForSeconds(0.5f);
        tableAnim.SetBool("open", true);
        PlayerAnim.SetBool("pickup", false);
        PlayerAnim.SetBool("pickupmid", false);
        Solved = true;
        Key.SetActive(false);
        ContainerPart.SetActive(true);

    }
}


