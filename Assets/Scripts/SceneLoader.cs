using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        int currentSceneIndex = GetSceneIndex();
        PlayerPrefsController.SetLevelPlayed(currentSceneIndex);
    }
    public void LoadNextLevel()
    {
        int currentSceneIndex = GetSceneIndex();
        SceneManager.LoadScene(++currentSceneIndex);
    }
    public void RestartLevelWithDelay(float seconds) {
        int currentSceneIndex = GetSceneIndex();
        StartCoroutine(Delay(currentSceneIndex, seconds));
    }

    public void RestartLevel()
    {
        int currentSceneIndex = GetSceneIndex();
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadSelectedLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public int GetSceneIndex() {
        return SceneManager.GetActiveScene().buildIndex;
    }

    IEnumerator Delay(int sceneIndex, float seconds) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneIndex);
    }
}
