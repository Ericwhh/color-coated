using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string LEVEL_KEY = "level";
    const string MUSIC_KEY = "music";
    const string SFX_KEY = "sfx";

    public static void SetLevelPlayed(int level) {
        PlayerPrefs.SetInt(LEVEL_KEY + level, level);
    }

    public static bool HasReachedLevel(int level)
    {
        return PlayerPrefs.HasKey(LEVEL_KEY + level);
    }

    public static void ResetProgress() {
        PlayerPrefs.DeleteAll();
    }

    public static bool ReachedLevelOne() {
        return PlayerPrefs.HasKey(LEVEL_KEY + "2");
    }

    public static void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat(SFX_KEY, volume);
    }

    public static float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(SFX_KEY);
    }

    public static void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(MUSIC_KEY, volume);
    }

    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_KEY);
    }

    public static bool HasSetMusicVolume() {
        return PlayerPrefs.HasKey(MUSIC_KEY);
    }

    public static bool HasSetSFXVolume()
    {
        return PlayerPrefs.HasKey(SFX_KEY);
    }
}
