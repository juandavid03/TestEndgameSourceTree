using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    //Class that hides and shows objects, has to be called from the object that collides (player in this case) with this game object.
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
