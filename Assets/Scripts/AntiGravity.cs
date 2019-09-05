using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour
{
    ColorHandler colorHandler;
    ParticleSystemRenderer myParticleSystemRenderer;
    AudioSource audioSource;

    private void Start()
    {
        colorHandler = FindObjectOfType<ColorHandler>();
        myParticleSystemRenderer = GetComponent<ParticleSystemRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReverseGravity(collision);
    }

    private void ReverseGravity(Collider2D collision)
    {
        Color gravityColor = myParticleSystemRenderer.material.color;

        if (colorHandler.ColorContain(gravityColor))
        {
            float gravity = transform.rotation.z == 0f ? 1f : -1f;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -gravity;
            AudioSource.PlayClipAtPoint(audioSource.clip, Camera.main.transform.position, PlayerPrefsController.GetSFXVolume() / 10f);
        }
    }
}
