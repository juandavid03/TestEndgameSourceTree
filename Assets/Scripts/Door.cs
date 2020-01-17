using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Animator animControl;

    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip doorClip;

    //Variable to  check if the player has the correct key to open the door.
    [SerializeField]
    private string lockForKey;
    public string LockForKey
    {
        get { return lockForKey; }
    }

    //Opens the door on collision with the player.
    public void OpenDoor()
    {
        animControl.SetTrigger("openDoor");
        source.PlayOneShot(doorClip);
    }

    //Disappears the door at the end of the animation, called with an animation event.
    public void DisappearDoor()
    {
        this.gameObject.SetActive(false);
    }
}
