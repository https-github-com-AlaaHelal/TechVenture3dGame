﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingItems : MonoBehaviour
{
    bool nearToItem = false;
    public int LayerMask = 1 << 11;
    public Item item;

    private GameObject floor;
    private GameObject Player;
    private Animator PlayerAnim;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerAnim = Player.GetComponent<Animator>();
        floor = GameObject.FindGameObjectWithTag("Floor");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 20, LayerMask))
            {
                Debug.Log(hit.collider.name);
                if (hit.transform == this.transform)
                {
                    if (!nearToItem)
                        print("Get Closer");
                    
                }

            }

        }


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            print("press Space");
            nearToItem = true;

        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(PickUp());
            }
        }
    }
    float FindDistance()
    {
        return Vector3.Distance(new Vector3(0, transform.position.y, 0), new Vector3(0, floor.transform.position.y, 0));
    }
    IEnumerator PickUp()
    {
        
        Debug.Log(transform.position);
        Debug.Log(Player.transform.rotation);
        if (FindDistance() >= 3)
        {
            PlayerAnim.SetBool("pickup", true);
            PlayerAnim.SetBool("pickupmid", true);
            yield return new WaitForSeconds(1f);
        }
        else
        {
            PlayerAnim.SetBool("pickup", true);
            PlayerAnim.SetBool("pickuplow", true);
            yield return new WaitForSeconds(1f);
        }
        gameObject.SetActive(false);
        bool wasPickedUp = Inventory.instance.Add(item);
        PlayerAnim.SetBool("pickup", false);
        PlayerAnim.SetBool("pickupmid", false);
        PlayerAnim.SetBool("pickuplow", false);
    }
}

