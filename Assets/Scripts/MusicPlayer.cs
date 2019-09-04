using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip returnSound;

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
        GetComponent<AudioSource>().Play();
    }

    public void UpdateBGAudioLevel() {
        GetComponent<AudioSource>().volume = PlayerPrefsController.GetMusicVolume() / 10f;
    }

    public void PlaySFX(AudioClip clip) {
        float prevTimeScale = Time.timeScale;
        Time.timeScale = 1f;
        DontDestroyOnLoad(clip);
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, PlayerPrefsController.GetSFXVolume());
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
