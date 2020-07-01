using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenClueAppeared : MonoBehaviour
{
    public Transform player;
    public GameObject buttonHand;
    public GameObject buttonOnTable;
    public float Distance = 5;
    Animator playeranime;
    public int animatiomnumber;
    public GameObject screenClue;
    public bool solved;
    // Start is called before the first frame update
    void Start()
    {
        playeranime = player.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Vector3.Dot(player.forward, transform.forward);
        float distance = Vector3.Distance(player.position, this.transform.position);

        if (direction >= 0.9 && distance <= Distance)
        {
            print("Press 'E'");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (buttonHand.activeSelf)
                {
                    solved = true;
                    StartCoroutine(Animation());
                    this.GetComponent<ScreenClueAppeared>().enabled = false;
                }
                else
                {
                    print("You need to get the button");
                }
            }
        }
    }

    IEnumerator Animation()
    {
        playeranime.SetBool("pickup", true);
        playeranime.SetInteger("action", animatiomnumber);
        yield return new WaitForSeconds(1f);
        playeranime.SetInteger("action", 0);
        playeranime.SetBool("pickup", false);
        buttonHand.SetActive(false);
        yield return new WaitForSeconds(1f);
        buttonOnTable.SetActive(true);
        yield return new WaitForSeconds(1f);
        screenClue.SetActive(true);


    }
}
