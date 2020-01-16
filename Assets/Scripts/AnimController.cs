using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private VirtualController controller;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        if(controller ==null)
        {
            controller = this.GetComponent<VirtualController>();
        }
    }
    public void SetRunningVariable(bool currentRunningState)
    {
        anim.SetBool("isRunning", currentRunningState);
    }

    public void SetShootingVariable(bool currentShootingState)
    {
        anim.SetBool("isShooting", currentShootingState);
    }

    public void SetShootingTrigger()
    {
        anim.SetTrigger("shoot");
    }
}
