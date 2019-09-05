using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfPlayArea : MonoBehaviour
{
    [SerializeField] ParticleSystem deathEffect;

    SceneLoader sceneLoader;
    AudioSource audioSource;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreateDeathVFX(collision);
        CreateDeathSFX();
        Destroy(collision.gameObject);
        sceneLoader.RestartLevelWithDelay();
    }

    private void CreateDeathSFX()
    {
        AudioSource.PlayClipAtPoint(audioSource.clip, Camera.main.transform.position, PlayerPrefsController.GetSFXVolume() / 10f);
    }

    private void CreateDeathVFX(Collider2D collision)
    {
        ParticleSystem particleSystem = Instantiate(deathEffect, collision.transform.position, Quaternion.identity);
        ParticleSystemRenderer renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        renderer.material.color = collision.gameObject.GetComponent<MeshRenderer>().material.color;
    }
}
