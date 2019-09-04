using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] GameObject levelSelectCanvas;

    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject levelSelectButton;

    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSFX;

    MusicPlayer musicPlayer;

    const float defaultMusicVolume = 0.5f;
    const float defaultSFXVolume = 0.5f;

    private void Start()
    {
        ResetToStartingState();
        ShowLevelSelect();
        musicPlayer = FindObjectOfType<MusicPlayer>();
        musicPlayer.UpdateBGAudioLevel();
    }

    private static void ResetToStartingState()
    {
        Time.timeScale = 1f;
    }

    public void Options()
    {
        mainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
        SetVolumeSliderValues();
    }

    private void SetVolumeSliderValues()
    {
        if (PlayerPrefsController.HasSetSFXVolume())
        {
            sliderSFX.value = PlayerPrefsController.GetSFXVolume();
        } 
        if (PlayerPrefsController.HasSetMusicVolume())
        {
            sliderMusic.value = PlayerPrefsController.GetMusicVolume();
        }
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
        HideUnreachedLevels();
    }

    private void ShowLevelSelect() {
        if (PlayerPrefsController.ReachedLevelOne())
        {
            startGameButton.SetActive(false);
            levelSelectButton.SetActive(true);
        }
    }

    private void HideUnreachedLevels() {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("LevelSelect");
        int numberOfLevels = buttons.Length;
        for (int level = 1; level <= numberOfLevels; level++) {
            if (!PlayerPrefsController.HasReachedLevel(level))
            {
                buttons[level - 1].SetActive(false);
            }
        }
    }
    
    public void UpdateMusicLevel() {
        PlayerPrefsController.SetMusicVolume(sliderMusic.value);
        musicPlayer.UpdateBGAudioLevel();
    }

    public void UpdateSFXLevel()
    {
        PlayerPrefsController.SetSFXVolume(sliderSFX.value);
    }
}
