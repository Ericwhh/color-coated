using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string LEVEL_KEY = "level";
    const string MUSIC_KEY = "music";
    const string SFX_KEY = "SFX";

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
}
