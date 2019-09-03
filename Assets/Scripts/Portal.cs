using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
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
        GetComponent<BoxCollider2D>().isTrigger = colorHandler.ColorMatch(myMeshRenderer.material.color);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colorHandler.PlayerLoseColor(myMeshRenderer.material.color);
    }
}
