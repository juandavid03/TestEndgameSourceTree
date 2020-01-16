using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
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
