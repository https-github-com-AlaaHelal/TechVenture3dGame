using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] Deactive;
    public GameObject[] puzzle2d;
    public GameObject[] animatedObj;
    // Start is called before the first frame update
    void Start()
    {
        if(SaveLoadManager.instance.ActiveObjectsIDs.Count > 0 )
        {
            foreach(GameObject GO in Deactive)
            {
                if (SaveLoadManager.instance.ActiveObjectsIDs.Contains(GO.GetComponent<ItemID>().ID))
                    GO.SetActive(true);
            }
        } if(SaveLoadManager.instance.AnimateOBjectIDs.Count > 0 )
        {
            foreach(GameObject Obj in animatedObj)
            {
                if (SaveLoadManager.instance.AnimateOBjectIDs.Contains(Obj.GetComponent<ItemID>().ID))
                    Obj.GetComponent<Animator>().SetBool("open", true);
            }
        }
    }

}
