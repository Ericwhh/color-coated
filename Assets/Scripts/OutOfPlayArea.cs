using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfPlayArea : MonoBehaviour
{
    SceneLoader sceneLoader;
    [SerializeField] ParticleSystem deathEffect;
    [SerializeField] float deathDelay = 2f;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ParticleSystem particleSystem = Instantiate(deathEffect, collision.transform.position, Quaternion.identity);
        ParticleSystemRenderer renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        renderer.material.color = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        Destroy(collision.gameObject);
        sceneLoader.RestartLevelWithDelay(deathDelay);
    }
}
