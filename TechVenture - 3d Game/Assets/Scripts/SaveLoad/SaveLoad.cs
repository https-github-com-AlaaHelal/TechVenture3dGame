using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
    public static System.Action SaveInitiated;
    public static void Save<T>(T Object, string Key)
    {
        string path = Application.persistentDataPath + "/saves/";
        Directory.CreateDirectory(path);

        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream fileStream = new FileStream(path  + Key + ".txt", FileMode.Create))
        {
            formatter.Serialize(fileStream, Object);
        }
        Debug.Log("save");
    }

    public static T Load<T>(string Key)
    {
        string path = Application.persistentDataPath + "/saves/";

        BinaryFormatter formatter = new BinaryFormatter();

        T returnVal = default;
        using (FileStream fileStream = new FileStream(path + Key + ".txt", FileMode.Open))
        {
            returnVal = (T)formatter.Deserialize(fileStream);
        }
        return returnVal;
    }

    public static bool SaveExists(string Key)
    {
        string path = Application.persistentDataPath + "/saves/" + Key + ".txt";
        return File.Exists(path);
    }

    public static void DeleteAllSaveFiles()
    {
        string path = Application.persistentDataPath + "/saves/";
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        directoryInfo.Delete();
        Directory.CreateDirectory(path);
    }
}
