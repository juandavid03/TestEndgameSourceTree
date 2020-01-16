using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : AIStateBase
{

    private float searchTimer;

    public AlertState(AIController controlled) : base(controlled)
    {
    }

    public override void UpdateState()
    {
        Search();
        LookAround();
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

    private void LookAround()
    {
        controlled.navMeshAgent.isStopped = true;
        controlled.transform.Rotate(0, controlled.searchingTurnSpeed * Time.deltaTime, 0);
        searchTimer += Time.deltaTime;

        if (searchTimer >= controlled.searchingDuration)
            ToPatrolState();
    }

    private void ToPatrolState()
    {
        searchTimer = 0f;
        controlled.MakeTransition(EnemyState.Patrol);
    }
}
