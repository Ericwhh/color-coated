using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip backSound;

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

    public void PlaySFX(AudioClip clip) {
        DontDestroyOnLoad(clip);
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
}
