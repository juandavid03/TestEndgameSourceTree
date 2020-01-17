using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    //Manages the keys, makes them spin for a nice effect, and stores the info of the door it opens.
    [SerializeField]
    private string key;
    private float rotationSpeed = 100;

    public string Value
    {
        get { return key; }
    }

    public void Disapear()
    {
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, rotationSpeed * Time.deltaTime);
    }
}
