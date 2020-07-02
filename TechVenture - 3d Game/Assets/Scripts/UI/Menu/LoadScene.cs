using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject Menu;

    public GameObject LoadingScreen;
    public Slider Slider;
    public void StartNew(int sceneIndex)
    {
        string playerDataPath = Application.persistentDataPath + "/saves/playerData";
        string[] allSavedFiles = Directory.GetFiles(Application.persistentDataPath + "/saves");
        foreach (string file in allSavedFiles)
        {
            if (!file.Equals(playerDataPath))
            {
                File.Delete(file);
            }
        }
        Menu.SetActive(false);
        StartCoroutine(LoadAsync(sceneIndex));
    }
    public void LoadingScene(int sceneIndex)
    {
        Menu.SetActive(false);
        StartCoroutine(LoadAsync(sceneIndex));
    }
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            Slider.value = operation.progress;
            yield return null;
        }
    }
}
