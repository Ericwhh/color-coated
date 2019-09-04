using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    ColorHandler colorHandler;
    MeshRenderer myMeshRenderer;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] float delay = 2f;
    AudioSource audioSource;
    bool hasCollided = false;

    private void Start()
    {
        colorHandler = FindObjectOfType<ColorHandler>();
        myMeshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (colorHandler.ColorMatch(myMeshRenderer.material.color) && !hasCollided)
        {
            hasCollided = true;
            sceneLoader = FindObjectOfType<SceneLoader>();
            sceneLoader.LoadNextLevelWithDelay();
            AudioSource.PlayClipAtPoint(audioSource.clip, Camera.main.transform.position);
        }
    }
}
