using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour
{
    ColorHandler colorHandler;
    MeshRenderer myMeshRenderer;

    private void Start()
    {
        colorHandler = FindObjectOfType<ColorHandler>();
        myMeshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReverseGravity(collision);
    }

    private void ReverseGravity(Collider2D collision)
    {
        ParticleSystem.MainModule main = GetComponent<ParticleSystem>().main;
        Color gravityColor = main.startColor.color;
        if (colorHandler.ColorMatch(gravityColor))
        {
            float gravity = collision.gameObject.GetComponent<Rigidbody2D>().gravityScale;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -gravity;
        }
    }
}
