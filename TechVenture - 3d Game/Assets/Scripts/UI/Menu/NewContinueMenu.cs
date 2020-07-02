using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewContinueMenu : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider Slider;
    public void StartNew()
    {
        string playerDataPath = Application.persistentDataPath + "/saves/playerData";
        string[] allSavedFiles = Directory.GetFiles(Application.persistentDataPath + "/saves");
        foreach(string file in allSavedFiles)
        {
            if (!file.Equals(playerDataPath))
            {
                File.Delete(file);
            }
        }
    }
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Slider.value = progress;
            yield return null;
        }
    }
}
