using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCard : MonoBehaviour
{
    public Item KeyCard;
    public GameObject Player;

    private Animator PlayerAnim;
    private bool PickedUp = false;

    private void Start()
    {
        PlayerAnim = Player.GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (!PickedUp && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(TakeKey(Player));
            PickedUp = Inventory.instance.Add(KeyCard);
        }
    }
    IEnumerator TakeKey(GameObject player)
    {
        //Animator playerAnim = player.GetComponent<Animator>();
        PlayerAnim.SetBool("pickup", true);
        PlayerAnim.SetBool("pickupmid", true);

        //Inventory.instance.Add(KeyCard);
        yield return new WaitForSeconds(0.5f);
        // Destroy(CardShow.instance.Card2);
        PlayerAnim.SetBool("pickupmid", false);
        PlayerAnim.SetBool("pickup", false);

        Destroy(CardShow.instance.Card2);
        PickedUp = false;
    }
}
