using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeManager : MonoBehaviour
{
    public Animator playeranimatore;
    public Transform player;
    public float Distance = 7;
    public GameObject SafeCanvas;
    public GameObject camerascript;
    GameObject Safe;
    // Start is called before the first frame update
    void Start()
    {
        Safe = GameObject.FindGameObjectWithTag("SAFE");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (Input.GetKeyDown(KeyCode.Escape)&& distance<Distance)
            {
                Safe.SetActive(true);
                SafeCanvas.SetActive(false);
                camerascript.GetComponent<camera>().enabled = true;
                playeranimatore.gameObject.SetActive(true);

            }



    }
}
