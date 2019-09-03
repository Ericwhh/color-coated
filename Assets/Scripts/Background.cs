using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Animator myAnimator;
    Player player;
    MeshRenderer myMeshRenderer;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        myMeshRenderer = GetComponent<MeshRenderer>();
        TriggerCircularExpansion();
    }

    public void TriggerCircularExpansion() {
        myMeshRenderer.material.color = new Color(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1), 1);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        myAnimator.SetTrigger("Pickup");
    }
}
