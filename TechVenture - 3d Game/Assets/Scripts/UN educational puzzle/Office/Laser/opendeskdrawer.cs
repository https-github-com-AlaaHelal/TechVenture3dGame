using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendeskdrawer : MonoBehaviour
{
    public GameObject laserscript;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (laserscript.GetComponent<ExitPuzzle>().Exit)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Animation());
            }
        }

    }
    IEnumerator Animation()
    {

        player.GetComponent<Animator>().SetBool("pickup", true);
        player.GetComponent<Animator>().SetInteger("action", 2);
        this.GetComponent<Animator>().SetBool("open", true);
        yield return new WaitForSeconds(1f);
        player.GetComponent<Animator>().SetInteger("action", 0);
        player.GetComponent<Animator>().SetBool("pickup", false);

    }
}
