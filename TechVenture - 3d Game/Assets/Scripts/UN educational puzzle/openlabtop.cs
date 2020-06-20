using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openlabtop : MonoBehaviour
{
    public Transform player;
    public GameObject flash;
    public float Distance = 5;
    Animator playeranime;
    public int animatiomnumber;
    public GameObject passimge;
    public GameObject laptoboutline;
    public bool solved;

    // Start is called before the first frame update
    void Start()
    {
        playeranime = player.gameObject.GetComponent<Animator>();
        passimge.SetActive(false);
        laptoboutline.SetActive(false);
        flash.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = (this.transform.position - player.position).normalized;
        float direction = Vector3.Dot(player.forward, transform.forward);
        float distance = Vector3.Distance(player.position, this.transform.position);
        //   Debug.Log(distance);
        if (direction >= 0.9 && distance <= Distance )
        {
            laptoboutline.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (flash.activeSelf)
                {
                    solved = true;

                    StartCoroutine(Animation());
                    this.GetComponent<openlabtop>().enabled = false;
                }
                else
                {
                    Debug.Log("you need a flashmemory");
                }
            }
        }
        else
        {
            laptoboutline.SetActive(false);

        }
    }
    IEnumerator Animation()
    {
        Destroy(laptoboutline);
        playeranime.SetBool("pickup", true);
        playeranime.SetInteger("action", animatiomnumber);
        yield return new WaitForSeconds(1f);
        playeranime.SetInteger("action", 0);
        playeranime.SetBool("pickup", false);
        flash.SetActive(false);
        yield return new WaitForSeconds(1f);
        passimge.SetActive(true);

    }
}
