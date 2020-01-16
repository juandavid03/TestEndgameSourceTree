using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public SpriteRenderer hideableObjectRenderer;

    public void HideObjects()
    {
        hideableObjectRenderer.enabled = false;
    }

    public void ShowObjects()
    {
        hideableObjectRenderer.enabled = true;
    }
}
