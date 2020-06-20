using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openboard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject outline;

    public Transform player;
    public float Distance = 5;
    public GameObject Camera;
    public int animatiomnumber;
    public GameObject safescript;

    Animator playeranime;
    bool Rotate = false;
    bool ReturnPosition = false;
    Quaternion OriginalRotation;
    Quaternion StopAngle;
    // Start is called before the first frame update
    void Start()
    {
        playeranime = player.gameObject.GetComponent<Animator>();
        safescript.GetComponent<OpenSafe>().enabled = false;
        outline.SetActive(false);
        StopAngle = transform.localRotation * Quaternion.Inverse(Quaternion.Euler(35, 0, 0));
        OriginalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = (this.transform.position - player.position).normalized;
        float direction = Vector3.Dot(player.forward, transform.forward);
        float distance = Vector3.Distance(player.position, this.transform.position);
        if (direction < 0.9 && distance <= Distance)
        {
            outline.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
              //  Camera.GetComponent<camera>().enabled = false;
                StartCoroutine(HoldBoard());
            }
           
        }
        else
        {
            outline.SetActive(false);

        }
        if (Rotate)
        {
            transform.RotateAround(transform.parent.position, transform.parent.forward, 20 * Time.deltaTime);
            if (transform.localRotation.x <= Math.Round(StopAngle.x, 3))
                Rotate = false;
        }
        if (ReturnPosition)
        {
            transform.RotateAround(transform.parent.position, transform.parent.forward, -40 * Time.deltaTime);
            if (transform.localRotation.x >= Math.Round(OriginalRotation.x, 3))
                ReturnPosition = false;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Release");
            ReleaseBoard();
        }
    }
    void ResetBoardPosition()
    {

    }
    IEnumerator Animation()
    {
        playeranime.SetBool("pickup", true);
        playeranime.SetInteger("action", animatiomnumber);
        yield return new WaitForSeconds(1f);
        playeranime.SetInteger("action", 0);
        Rotate = true;
        playeranime.SetBool("pickup", false);
        yield return new WaitForSeconds(1f);
        safescript.GetComponent<OpenSafe>().enabled = true;


    }
    IEnumerator HoldBoard()
    {
        yield return new WaitForSeconds(0.05f);
        playeranime.SetBool("pickup", true);
        playeranime.SetInteger("action", animatiomnumber);
        yield return new WaitForSeconds(0.2f);
        Rotate = true;
        yield return new WaitForSeconds(1.3f);
        playeranime.SetInteger("action", 0);
        playeranime.SetBool("pickup", false);
        safescript.GetComponent<OpenSafe>().enabled = true;
    }
    void ReleaseBoard()
    {
        ReturnPosition = true;
        Camera.GetComponent<camera>().enabled = true;
        safescript.GetComponent<OpenSafe>().enabled = false;
    }
}
