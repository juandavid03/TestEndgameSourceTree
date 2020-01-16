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
        Debug.Log("Can Shoot: " + controlled.CanShoot);
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
            Debug.Log("ESTOY EN RANGE");

                LookAtPlayer();
                Debug.Log("LOOKING AT PLAYER ES DISTINTO DE NULL");
                Shoot();
            }

        }
        else
        {
            Debug.Log("ESTOY EN EL ELSE, VOY A HACER SEARCH");
            Search();
        }
    }

    private void Shoot()
    {
        Debug.Log("ENTRE A SHOOT");
        if (controlled.CanShoot == true)
        {
            Debug.Log("VOY A DISPARAR");

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
            controlled.MakeTransition(EnemyState.Alert);
        }
    }

    private void ToChase(Transform player)
    {
        controlled.chaseTarget = player;
        controlled.MakeTransition(EnemyState.Chase);
    }
}
