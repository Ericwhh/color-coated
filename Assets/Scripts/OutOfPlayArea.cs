using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfPlayArea : MonoBehaviour
{
    SceneLoader sceneLoader;
    [SerializeField] ParticleSystem deathEffect;
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ParticleSystem particleSystem = Instantiate(deathEffect, collision.transform.position, Quaternion.identity);
        ParticleSystem.MainModule main = particleSystem.main;
        main.startColor = new ParticleSystem.MinMaxGradient(collision.gameObject.GetComponent<MeshRenderer>().material.color);
        Destroy(collision.gameObject);
        sceneLoader.RestartLevel();
    }
}
