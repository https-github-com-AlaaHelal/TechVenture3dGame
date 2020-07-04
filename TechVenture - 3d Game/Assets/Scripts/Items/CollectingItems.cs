﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingItems : MonoBehaviour
{
    bool nearToItem = false;
    public int LayerMask = 1 << 11;
    public Item item;
 //   public Information information;
    private GameObject floor;
    private GameObject Player;
    private Animator PlayerAnim;
    private int Picked;
    public float speed = 3.0f;
    public GameObject outline;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerAnim = Player.GetComponent<Animator>();
        floor = GameObject.FindGameObjectWithTag("Floor");
        Picked = 0;
        if(outline != null)
         outline.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 20, LayerMask))
            {
              //  Debug.Log(hit.collider.name);
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
            //print("enter f");
            nearToItem = true;
        }
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (outline != null)
            {
                outline.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Picked++;
            }
            if (Picked == 1)
            {
                //LookRotation
               // LookAt();
                //Lookat
               // Player.transform.LookAt(this.gameObject.transform, this.gameObject.transform.position);
                StartCoroutine(PickUp());
                Destroy(outline);
            }
        }
    }
    float FindDistance()
    {
        return Vector3.Distance(new Vector3(0, transform.position.y, 0), new Vector3(0, floor.transform.position.y, 0));
    }
    IEnumerator PickUp()
    {

        bool wasPickedUp = Inventory.instance.Add(item);

        if (FindDistance() >= 3)
        {
            PlayerAnim.SetBool("pickup", true);
            PlayerAnim.SetBool("pickupmid", true);
            yield return new WaitForSeconds(1f);
            PlayerAnim.SetBool("pickupmid", false);
            PlayerAnim.SetBool("pickup", false);

        }
        else
        {
            PlayerAnim.SetBool("pickup", true);
            PlayerAnim.SetBool("pickuplow", true);
            yield return new WaitForSeconds(1f);
            PlayerAnim.SetBool("pickuplow", false);
            PlayerAnim.SetBool("pickup", false);

        }
        gameObject.SetActive(false);
        // bool wasPickedUp = Inventory.instance.Add(item);

        //else if (information)
        //{
        //    gameObject.SetActive(false);
        //    bool wasPicked = InformationInventory.instance.Add(information);
        //}
        //// Debug.Log(wasPickedUp);

    }
    void LookAt()
    {
        Vector3 target, character;
        target = this.gameObject.transform.position;
        character = Player.transform.position;

        Vector3 Direction = target - character;
        Quaternion rotation = Quaternion.LookRotation(Direction);
        Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, rotation, Time.deltaTime * speed);
    }
}

