using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string LEVEL_KEY = "level";
    public static void SetLevelPlayed(int level) {
        PlayerPrefs.SetInt(LEVEL_KEY + level, level);
    }

    public static void ResetProgress() {
        PlayerPrefs.DeleteAll();
    }

    public static bool BeatLevelOne() {
        return PlayerPrefs.HasKey(LEVEL_KEY + "2");
    }
}
