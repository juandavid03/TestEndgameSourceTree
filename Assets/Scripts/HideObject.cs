using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    //Hides objects, must be calleed from the Player controller when it collides with an object. 
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
