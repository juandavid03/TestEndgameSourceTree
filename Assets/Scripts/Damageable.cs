using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    //Class to manage player's and AI's healths

    private float hitPoints;
    public float HitPoints
    {
        get { return hitPoints; }
    }

    //Stored to change the length of the healthbar.
    private CanvasManager canvasController;

    private void Start()
    {
        hitPoints = 1f;
        canvasController = GameObject.Find("CanvasManager").GetComponent<CanvasManager>();
    }

    //Reduce Hitpoints.
    public void TakeDamage()
    {
        hitPoints -= 0.25f;
        if (this.gameObject.CompareTag("Player"))
        {
            canvasController.ReduceHpBar(HitPoints);
        }

    }

    //Method to end the current run if player looses or destroy a killed enemy.
    public void Die()
    {
        if(this.gameObject.CompareTag("enemy"))
        {
            this.gameObject.SetActive(false);
        }
        if (this.gameObject.CompareTag("Player"))
        {
            SceneController._instance.LoadMenuScene();

        }

    }

}
