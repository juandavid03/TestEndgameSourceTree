using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public SpriteRenderer hideableObjectRenderer;


    /*private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Object: " + this.gameObject.name + " Has collided with player");
            HideObjects();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Object: " + this.gameObject.name + " Has exited collision with player");
            ShowObjects();
        }
    }*/

    public void HideObjects()
    {
        hideableObjectRenderer.enabled = false;
    }

    public void ShowObjects()
    {
        hideableObjectRenderer.enabled = true;
    }
}
