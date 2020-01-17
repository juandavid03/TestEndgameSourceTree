using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    //Class in charge of managing the health of AI & Player
    private float hitPoints;
    public float HitPoints
    {
        get { return hitPoints; }
        set { hitPoints = value; }
    }

    private CanvasManager canvasController;
    // Start is called before the first frame update
    private void Start()
    {
        hitPoints = 1f;
        canvasController = GameObject.Find("CanvasManager").GetComponent<CanvasManager>();
    }


    public void TakeDamage()
    {
        hitPoints -= 0.25f;
        if (this.gameObject.CompareTag("Player"))
        {
            canvasController.ReduceHpBar(HitPoints);
        }

    }


    public void Die()
    {
        if(this.gameObject.CompareTag("enemy"))
        {
            EnemyPool._instance.RecycleObject(this.gameObject);

        }
        if (this.gameObject.CompareTag("Player"))
        {
            SceneController._instance.LoadMenuScene();

        }

    }

}
