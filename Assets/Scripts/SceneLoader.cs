using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentSceneIndex);
    }
    public void RestartLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(Delay(currentSceneIndex, 2f));
    }
    
    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

    IEnumerator Delay(int sceneIndex, float seconds) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneIndex);
    }
}
