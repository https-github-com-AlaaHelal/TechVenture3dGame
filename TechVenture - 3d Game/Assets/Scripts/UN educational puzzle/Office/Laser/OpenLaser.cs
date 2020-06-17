﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLaser : MonoBehaviour
{
    public Transform player;
    public float Distance = 10;
    public GameObject Puzzle;
    public Canvas canvas;
    public GameObject Line;
    public bool LaserPuzzleActive;
    public int Win;
    public GameObject Camera;
    public GameObject deskoutline;
    private Animator DeskAnimator;
    private void Start()
    {
        DeskAnimator = gameObject.GetComponent<Animator>();
        deskoutline.SetActive(false);
            }
    // Update is called once per frame;
    void Update()
    {
        if(Win == 0)
        {
            float direction = Vector3.Dot(player.forward.normalized, transform.forward.normalized);
            float distance = Vector3.Distance(player.position, transform.position);
            if (direction >= 0.9 && distance <= Distance )
            {
                deskoutline.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Puzzle.GetComponent<ExitPuzzle>().Exit = false;
                    LaserPuzzleActive = true;
                    Camera.GetComponent<camera>().enabled = false;
                }
            }
            else
            {
                deskoutline.SetActive(false);

            }
            if (Camera.GetComponent<camera>().mouseSensitivity >= 0 && LaserPuzzleActive)
            {
                
                StartCoroutine(Open());
            }
        }
        if (Win == 1)
        {
            StartCoroutine(Exit());
            Win++;
        }
    }
    IEnumerator Exit()
    {
        yield return new WaitForSeconds(0.5f);
        canvas.enabled = false;
        LaserPuzzleActive = false;

        DeskAnimator.SetBool("Open", true);
        Camera.GetComponent<camera>().enabled = true;
        Destroy(Puzzle);
    }
    
    IEnumerator Open()
    {
        yield return new WaitForSeconds(0.02f);
        Puzzle.SetActive(true);
        canvas.enabled = true;
    }
}
