using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Animator animControl;

    [SerializeField]
    private string lockForKey;

    public string LockForKey
    {
        get { return lockForKey; }
    }
    public void OpenDoor()
    {
        animControl.SetTrigger("openDoor");
    }

    public void DisappearDoor()
    {
        this.gameObject.SetActive(false);
    }
}
