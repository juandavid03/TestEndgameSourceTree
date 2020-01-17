using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    //Key class, gives it a nice spin, and contains a value to check against door values to see if it can open them.
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
