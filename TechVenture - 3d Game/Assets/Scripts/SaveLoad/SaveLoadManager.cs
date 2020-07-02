using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;
    public HashSet<string> CollectableItemIDs = new HashSet<string>();
    public HashSet<string> SolvedPuzzlesID = new HashSet<string>();
    public HashSet<string> ActiveObjectsIDs = new HashSet<string>();
    public HashSet<string> DeactiveObjectsIDs = new HashSet<string>();
    public HashSet<string> AnimateOBjectIDs = new HashSet<string>();

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;

        if (SaveLoad.SaveExists("InventoryIDs"))
        {
            SaveLoadManager.instance.CollectableItemIDs = SaveLoad.Load<HashSet<string>>("InventoryIDs");
        }
        if (SaveLoad.SaveExists("PuzzleIDs"))
        {
            SaveLoadManager.instance.SolvedPuzzlesID = SaveLoad.Load<HashSet<string>>("InventoryIDs");
        }
        if (SaveLoad.SaveExists("MoveableIDs"))
        {
            SaveLoadManager.instance.ActiveObjectsIDs = SaveLoad.Load<HashSet<string>>("InventoryIDs");
        }
        if (SaveLoad.SaveExists("DeactivatedObjects"))
        {
            SaveLoadManager.instance.DeactiveObjectsIDs = SaveLoad.Load<HashSet<string>>("DeactivatedObjects");
        }
    }

}
