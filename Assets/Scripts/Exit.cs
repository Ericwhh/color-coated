using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    ColorHandler colorHandler;
    MeshRenderer myMeshRenderer;
    [SerializeField] SceneLoader sceneLoader;
    private void Start()
    {
        colorHandler = FindObjectOfType<ColorHandler>();
        myMeshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (colorHandler.ColorMatch(myMeshRenderer.material.color))
        {
            sceneLoader = FindObjectOfType<SceneLoader>();
            sceneLoader.LoadNextLevel();
        }
    }
}
