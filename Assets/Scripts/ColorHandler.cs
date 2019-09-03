using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class ColorHandler : MonoBehaviour
{
    Player player;
    MeshRenderer playerMesh;
    Light2D playerGlow;
    Color playerColor;

    private void Start()
    {
        CachePlayer();
    }

    private void CachePlayer()
    {
        player = FindObjectOfType<Player>();
        playerMesh = player.GetComponent<MeshRenderer>();
        playerGlow = player.GetComponentInChildren<Light2D>();
        playerColor = playerMesh.material.color;
    }

    private void UpdatePlayerColor() {
        playerMesh.material.color = playerColor;
        playerGlow.color = playerColor;
    }

    public void PlayerGainColor(Color color)
    {
        if (ExceedColorMax(color))
        {
            SetDominantColor(color);
        }
        else
        {
            SetMixColor(color);
        }
        UpdatePlayerColor();
    }

    private void SetMixColor(Color newColor)
    {
        playerColor.r = Mathf.Min(playerColor.r + newColor.r, 1f);
        playerColor.g = Mathf.Min(playerColor.g + newColor.g, 1f);
        playerColor.b = Mathf.Min(playerColor.b + newColor.b, 1f);
        playerColor.a = 1f;
    }

    private bool ExceedColorMax(Color color) {
        return playerColor.r + color.r > 1 
            || playerColor.g + color.g > 1 
            || playerColor.b + color.b > 1;
    }

    private void SetDominantColor(Color color){
        float newRedValue = playerColor.r + color.r;
        float newGreenValue = playerColor.g + color.g;
        float newBlueValue = playerColor.b + color.b;
        if (newRedValue >= newGreenValue && newRedValue >= newBlueValue) {
            playerColor = Color.red;
        }
        else if (newGreenValue >= newRedValue && newGreenValue >= newBlueValue)
        {
            playerColor = Color.green;
        }
        else if (newBlueValue >= newRedValue && newBlueValue >= newGreenValue)
        {
            playerColor = Color.blue;
        }
    }

    public void PlayerLoseColor(Color color)
    {
        playerColor.r = Mathf.Max(playerColor.r - color.r, 0f);
        playerColor.g = Mathf.Max(playerColor.g - color.g, 0f);
        playerColor.b = Mathf.Max(playerColor.b - color.b, 0f);
        playerColor.a = 1f;
        UpdatePlayerColor();
    }

    public bool ColorMatch(Color color) {
        return playerColor == color;
    }

    public void SetBackgroundColor() {
        Color dimColor = playerColor / 2f;
        dimColor.a = 1f;
        Camera.main.backgroundColor = dimColor;
    }
}
