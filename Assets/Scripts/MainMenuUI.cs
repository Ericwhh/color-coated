using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] GameObject levelSelectCanvas;

    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject levelSelectButton;

    private void Start()
    {
        ResetToStartingState();
        ShowLevelSelect();
    }

    private static void ResetToStartingState()
    {
        Time.timeScale = 1f;
    }

    public void Options()
    {
        mainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void MainMenu() 
    {
        levelSelectCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void LevelSelect() {
        mainMenuCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
    }

    private void ShowLevelSelect() {
        if (PlayerPrefsController.BeatLevelOne())
        {
            startGameButton.SetActive(false);
            levelSelectButton.SetActive(true);
        }
    }
}
