using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public GameObject Player;
  

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerRobotCollision>().transition)
        {
            LoadNextScene();
        }
    }
    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(0));
    }
    IEnumerator LoadScene(int index)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(index);
    }
}
