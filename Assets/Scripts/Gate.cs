using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    ColorHandler colorHandler;
    MeshRenderer myMeshRenderer;

    private void Start()
    {
        colorHandler = FindObjectOfType<ColorHandler>();
        myMeshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        GetComponent<BoxCollider2D>().isTrigger = colorHandler.ColorContain(myMeshRenderer.material.color);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colorHandler.PlayerLoseColor(myMeshRenderer.material.color);
    }
}
