﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject gate;
    public GameObject Player;
    public GameObject PlayerCard;
    //public GameObject Key;

    private Animator PlayerAnim;
    private Animator GateAnim;
    //private Ray ray;
    //private RaycastHit hit;
    //private LayerMask mask;

    Inventory Inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        //ItemID = Key.GetComponent<ItemID>();
        GateAnim = gate.GetComponent<Animator>();
        PlayerAnim = Player.GetComponent<Animator>();
        Inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        //mask = 1 << 11;
    }

    // Update is called once per frame
    //float GetDirection()
    //{
    //    return Vector3.Dot(Player.transform.forward.normalized, transform.forward.normalized);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (Physics.Raycast(ray, out hit, 10, mask))
    //    {
    //        if(Input.GetMouseButton(0))
    //        {
    //            if (Inventory.SelectedSlot != null && Inventory.SelectedSlot.item != null)
    //            { 
    //                if (Inventory.SelectedSlot.item.name == "KeyCard")
    //                {
    //                    Inventory.Remove(Inventory.SelectedSlot.item);
    //                    StartCoroutine(openGate());
    //                }
    //            }

    //        }

    //    }

    //}
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Inventory.instance.SelectedSlot != null && Inventory.instance.SelectedSlot.item != null)
            {
                if (Inventory.instance.SelectedSlot.item.name == "KeyCard" && Input.GetKeyDown(KeyCode.E))
                {
                    Inventory.Remove(Inventory.SelectedSlot.item);
                    StartCoroutine(openGate());
                }
            }
        }
    }
    IEnumerator openGate()
    {
        PlayerCard.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        PlayerAnim.SetBool("pickup", true);
        PlayerAnim.SetBool("Card", true);
        //PlayerAnim.SetBool("pickup", true);
        yield return new WaitForSeconds(1f);
        GateAnim.SetBool("Open", true);
        yield return new WaitForSeconds(1f);
        PlayerAnim.SetBool("Card", false);
        PlayerAnim.SetBool("pickup", false);

        PlayerCard.SetActive(false);

    }
   
}
