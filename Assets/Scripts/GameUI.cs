using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    SceneLoader sceneLoader;
    private bool isPaused = false;
    
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        UpdateLevelText();
    }

    private void UpdateLevelText()
    {
        int currentSceneIndex = sceneLoader.GetSceneIndex();
        TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        text.text += currentSceneIndex;
    }

    public void PauseGame() {
        isPaused = true;
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
    }

    public void RetryLevel() {
        int currentSceneIndex = sceneLoader.GetSceneIndex();
        sceneLoader.LoadSelectedLevel(currentSceneIndex);
    }

    public bool IsPaused() {
        return isPaused;
    }
}
