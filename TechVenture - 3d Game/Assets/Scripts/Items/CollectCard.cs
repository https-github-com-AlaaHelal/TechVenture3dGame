using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCard : MonoBehaviour
{
    public Item KeyCard;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            other.GetComponent<Animator>().SetBool("pickup", true);
            other.GetComponent<Animator>().SetBool("pickupmid", true);
            Inventory.instance.Add(KeyCard);
            Destroy(CardShow.instance.Card2);
        }
    }
    IEnumerator TakeKey(GameObject player)
    {
        Animator playerAnim = player.GetComponent<Animator>();
        playerAnim.SetBool("pickup", true);
        playerAnim.SetBool("pickupmid", true);

        Inventory.instance.Add(KeyCard);
        yield return new WaitForSeconds(3);
        Destroy(CardShow.instance.Card2);

        playerAnim.SetBool("pickupmid", false);
        playerAnim.SetBool("pickup", false);
    }
}
