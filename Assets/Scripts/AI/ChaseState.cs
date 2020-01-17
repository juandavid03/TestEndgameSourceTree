using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AIStateBase
{
    private int range = 3;
    public ChaseState(AIController controlled) : base(controlled)
    {
    }

    public override void UpdateState()
    {
        Chase();
        Look();
    }

    private void Look()
    {
        Transform player = LookForPlayer();
        if (player != null)
        {
            controlled.chaseTarget = player;
            if (IsInRange())
            {
                controlled.navMeshAgent.isStopped = true;
                controlled.MakeTransition(EnemyState.Shooting);
            }
            else
            {
                Chase();
                controlled.navMeshAgent.isStopped = false;
            }
        }

        else
            ToAlert();

    }

    private void Chase()
    {
        Transform player = LookForPlayer();
        if (player != null)
        {
            controlled.navMeshAgent.SetDestination(controlled.chaseTarget.position);
            if (IsInRange())
            {
                controlled.MakeTransition(EnemyState.Shooting);
            }
            //Interaction when caught
        }
        else
            ToAlert();
    }

    private bool IsInRange()
    {
        return (controlled.chaseTarget.position - controlled.transform.position).magnitude < range;
    }

    private void ToAlert()
    {
        controlled.chaseTarget = null;
        controlled.MakeTransition(EnemyState.Alert);
    }


}
