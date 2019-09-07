using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    SceneLoader sceneLoader;
    MusicPlayer musicPlayer;

    private bool isPaused = false;
    
    private void Start()
    {
        UpdateLevelText();
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    private void Update()
    {
        KeyboardPauseClick();
        KeyboardRetryClick();
    }

    private void KeyboardRetryClick()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isPaused)
        {
            musicPlayer.PlaySFX(musicPlayer.GetClickSound());
            RetryLevel();
        }
    }

    private void KeyboardPauseClick()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                musicPlayer.PlaySFX(musicPlayer.GetClickSound());
                PauseGame();
            }
            else
            {
                musicPlayer.PlaySFX(musicPlayer.GetReturnSound());
                ResumeGame();
            }
        }
    }
    private void UpdateLevelText()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
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
