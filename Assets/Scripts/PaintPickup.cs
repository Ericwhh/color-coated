using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPickup : MonoBehaviour
{
    ColorHandler colorHandler;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangePlayerColor();
        AudioSource.PlayClipAtPoint(audioSource.clip, Camera.main.transform.position, PlayerPrefsController.GetSFXVolume());
        Destroy(gameObject);
    }

    private void ChangePlayerColor()
    {
        colorHandler = FindObjectOfType<ColorHandler>();
        Color paintColor = GetComponent<MeshRenderer>().material.color;
        colorHandler.PlayerGainColor(paintColor);
    }
}
