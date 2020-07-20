using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openmemorypuzzle : MonoBehaviour
{
    public Transform player;
    public GameObject puzzlescript;
    public int puzzlenumber;
    public float Distance = 5;
    public GameObject outline;
    public Animator imageanime;
    public GameObject images;



    // Start is called before the first frame update
    void Start()
    {
        images.SetActive(false);

        outline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = (this.transform.position - player.position).normalized;
        float direction = Vector3.Dot(player.forward, transform.forward);
        float distance = Vector3.Distance(player.position, this.transform.position);
        //   Debug.Log(distance);
        if (direction >= 0.9 && distance <= Distance)
        {
            outline.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                puzzlescript.GetComponent<UEPuzzleCanvas>().NumberofPuzzle = puzzlenumber;
                puzzlescript.GetComponent<UEPuzzleCanvas>().Display(puzzlenumber);

                StartCoroutine(imageanimation());
            }
        }
        else
        {
            outline.SetActive(false);

        }
    }
    IEnumerator imageanimation()
    {
        imageanime.SetBool("show", true);
        yield return new WaitForSeconds(2.5f);
        images.SetActive(true);
        images.GetComponent<Animator>().SetBool("show", true);
        imageanime.gameObject.SetActive(false);

    }
}
