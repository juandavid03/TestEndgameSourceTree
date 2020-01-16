using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class VirtualController : MonoBehaviour
{
    protected float MovementSpeed;
    protected int followAngleOffset;

    [SerializeField]
    protected AnimController animationController;
    protected bool isMoving;
    protected Rigidbody rb;

    [SerializeField]
    protected NavMeshAgent agent;
    protected BulletPool bulletPool;
    protected float hitPoints;

    protected Quaternion rotationToShoot;
    protected float FireRate = 4;
    protected float lastfired;


    [SerializeField]
    protected GameObject gun;
    protected abstract void LookTowardsTarget();
    protected abstract void MoveTowardsTarget();
    protected abstract void Shoot();
    public abstract void TakeDamage();
    protected abstract void Die();

    //protected abstract GameObject FindGun();
}
