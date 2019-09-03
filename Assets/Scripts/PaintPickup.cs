using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPickup : MonoBehaviour
{
    ColorHandler colorHandler;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colorHandler = FindObjectOfType<ColorHandler>();
        Color paintColor = GetComponent<MeshRenderer>().material.color;
        colorHandler.PlayerGainColor(paintColor);
        // colorHandler.SetBackgroundColor();
        Destroy(gameObject);
    }
}
