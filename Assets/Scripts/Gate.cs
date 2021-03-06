﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    ColorHandler colorHandler;
    MeshRenderer myMeshRenderer;
    BoxCollider2D myBoxCollider2D;
    AudioSource audioSource;

    private void Start()
    {
        colorHandler = FindObjectOfType<ColorHandler>();
        myMeshRenderer = GetComponent<MeshRenderer>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        UpdateTrigger();
    }

    private void UpdateTrigger()
    {
        myBoxCollider2D.isTrigger = colorHandler.ColorContain(myMeshRenderer.material.color);
        if (!myBoxCollider2D.isTrigger)
        {
            gameObject.layer = LayerMask.NameToLayer("Platform");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Gate");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(audioSource.clip, Camera.main.transform.position, PlayerPrefsController.GetSFXVolume() / 10f);
        colorHandler.PlayerLoseColor(myMeshRenderer.material.color);
    }
}
