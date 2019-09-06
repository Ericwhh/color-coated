using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip returnSound;
    private float defaultMusicVolume = 5f;
    private float defaultSFXVolume = 5f;

    private void Awake()
    {
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        SetDefaultVolume();
        GetComponent<AudioSource>().Play();
    }

    private void SetDefaultVolume()
    {
        if (!PlayerPrefsController.HasSetMusicVolume())
        {
            PlayerPrefsController.SetMusicVolume(defaultMusicVolume);
        }
        if (!PlayerPrefsController.HasSetSFXVolume())
        {
            PlayerPrefsController.SetSFXVolume(defaultSFXVolume);
        }
        UpdateBGAudioLevel();
    }

    public void UpdateBGAudioLevel() {
        GetComponent<AudioSource>().volume = PlayerPrefsController.GetMusicVolume() / 10f;
    }

    public void PlaySFX(AudioClip clip) {
        float prevTimeScale = Time.timeScale;
        Time.timeScale = 1f;
        DontDestroyOnLoad(clip);
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, PlayerPrefsController.GetSFXVolume() / 10f);
        Time.timeScale = prevTimeScale;
    }

    public AudioClip GetClickSound()
    {
        return clickSound;
    }

    public AudioClip GetReturnSound()
    {
        return returnSound;
    }
}
