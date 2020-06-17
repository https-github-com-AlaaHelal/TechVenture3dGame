using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openboard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject outline;

    public Transform player;
    public float Distance = 5;
    Animator playeranime;
    public int animatiomnumber;
    public GameObject safescript;
  

    // Start is called before the first frame update
    void Start()
    {
        playeranime = player.gameObject.GetComponent<Animator>();
        safescript.GetComponent<OpenSafe>().enabled = false;
        outline.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = (this.transform.position - player.position).normalized;
        float direction = Vector3.Dot(player.forward, transform.forward);
        float distance = Vector3.Distance(player.position, this.transform.position);
        //   Debug.Log(distance);
        if (direction < 0.9 && distance <= Distance)
        {
            outline.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Animation());
            }
        }
        else
        {
            outline.SetActive(false);

        }
    }
    IEnumerator Animation()
    {
        playeranime.SetBool("pickup", true);
        playeranime.SetInteger("action", animatiomnumber);
        yield return new WaitForSeconds(1f);
        playeranime.SetInteger("action", 0);
        playeranime.SetBool("pickup", false);
        yield return new WaitForSeconds(1f);
        safescript.GetComponent<OpenSafe>().enabled = true;


    }
}
