using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : AIStateBase
{

    private int nextWayPoint;
    private float range = 15f;

    public ShootingState(AIController controlled) : base(controlled)
    {

    }

    public override void UpdateState()
    {
        CheckForShot();
    }

    private bool isInRange()
    {
        return (controlled.chaseTarget.position - controlled.transform.position).magnitude < range;
    }

    public override void StartState()
    {
        Shoot();
    }

    public void CheckForShot()
    {
        if (LookForPlayer() != null)
        {
            if (isInRange())
            {
                LookAtPlayer();
                Shoot();
            }

        }
        else
        {
            Search();
        }
    }

    private void Shoot()
    {
        if (controlled.CanShoot == true)
        {

            controlled.StopAndShoot(controlled.chaseTarget.position - controlled.transform.position);

            controlled.CanShoot = false;

            controlled.StartCoroutine("shootCooldownCR");
        }
        else
        {
            controlled.StartCoroutine("shootCooldownCR");
        }
    }

    private void Search()
    {
        Transform player = LookForPlayer();
        if (player != null)
            ToChase(player);
        else
        {
            ToAlert();
        }
    }

    private void ToChase(Transform player)
    {
        controlled.chaseTarget = player;
        controlled.MakeTransition(EnemyState.Chase);
    }

    private void ToAlert()
    {
        controlled.chaseTarget = null;
        controlled.MakeTransition(EnemyState.Alert);
    }
}
