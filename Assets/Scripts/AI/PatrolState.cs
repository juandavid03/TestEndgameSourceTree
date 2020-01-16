using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AIStateBase
{

    private int nextWayPoint;

    private Vector3 currentPos;

    public PatrolState(AIController controlled) : base(controlled)
    {

    }

    public override void UpdateState()
    {
        Patrol();
        Search();
        Debug.Log("IS STOPPED? " + controlled.navMeshAgent.isStopped);
    }

    public override void StartState()
    {
        SetCurrentPath();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            controlled.MakeTransition(EnemyState.Alert);
    }

    private void Patrol()
    {
        currentPos = controlled.transform.position;
        if (!controlled.navMeshAgent.isStopped)
        {
            SetCurrentPath();
           
            if (Vector3.Distance(currentPos, controlled.wayPoints[nextWayPoint].position) < 2f)
            {
                nextWayPoint = (nextWayPoint + 1) % controlled.wayPoints.Length;
            }
        }
    }

    private void SetCurrentPath()
    {
        controlled.navMeshAgent.isStopped = false;
        controlled.navMeshAgent.SetDestination(controlled.wayPoints[nextWayPoint].position);
    }

    private void Search()
    {
        Transform player = LookForPlayer();
        if (player != null)
            ToChase(player);
    }

    private void ToChase(Transform player)
    {
        controlled.chaseTarget = player;
        controlled.MakeTransition(EnemyState.Chase);
    }
}
