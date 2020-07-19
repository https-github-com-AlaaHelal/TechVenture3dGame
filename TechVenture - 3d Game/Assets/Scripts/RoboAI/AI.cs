﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    
    public Animator anim;
    public Transform player;
    //public float Speed;

    public LineRenderer Laser;
    public GameObject Origin;
    public ParticleSystem Source;
    public bool Dead = false;

    public float Health = 100;
    public bool BeingShot = false;
    State currentState;
    NavMeshAgent agent;
    bool Dying;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentState = new IdleState(gameObject, anim, agent, player);
        Dying = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Distance = transform.position - player.transform.position;
        if (!Dead)
        {
           currentState = currentState.Process();
            Debug.Log(currentState);
        }
        else if(!Dying)
        {
            StartCoroutine(Die());
            Dying = true;
        }
        
    }
    public void TakeDamage(float amount)
    {
        Health -= amount;
        BeingShot = true;
        Debug.Log("ShootRobot");
    }
    IEnumerator Die()
    {
        //anim.SetBool("Death", true);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
