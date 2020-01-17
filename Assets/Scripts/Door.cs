using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    //Class in charge on managing the doors, opening them on collision and contains a value to check against the key to see if it's correct.
    [SerializeField]
    Animator animControl;

    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip doorClip;

    [SerializeField]
    private string lockForKey;

    public string LockForKey
    {
        get { return lockForKey; }
    }
    public void OpenDoor()
    {
        animControl.SetTrigger("openDoor");
        source.PlayOneShot(doorClip);
    }

    //Disappears the door, called by animation event on the end frame.
    public void DisappearDoor()
    {
        this.gameObject.SetActive(false);
    }
}
