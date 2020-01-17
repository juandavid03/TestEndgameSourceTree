using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Patrol, Chase, Alert, Shooting
}
public abstract class AIStateBase
{

    protected AIController controlled;

    public AIStateBase(
        AIController controlled)
    {
        this.controlled = controlled;
    }

    public virtual void StartState()
    {

    }

    public virtual void OnTriggerEnter(Collider other)
    {

    }

    public abstract void UpdateState();

    protected void LookAtPlayer()
    {
        controlled.transform.Rotate(controlled.chaseTarget.position);
        return;
    }

    protected Transform LookForPlayer()
    {
        RaycastHit hit;
        if (Physics.SphereCast(controlled.eyes.transform.position, 2f, controlled.eyes.transform.forward, out hit, controlled.sightRange) 
            && hit.collider.CompareTag("Player"))
        {
            return hit.transform;
        }
        else
            return null;
    }

}
