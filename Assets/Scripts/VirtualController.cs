using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class VirtualController : MonoBehaviour
{
    //Base class to keep AI & Player controller cleaner.
    protected float MovementSpeed;
    protected int followAngleOffset;

    [SerializeField]
    protected AnimController animationController;
    protected bool isMoving;
    protected Rigidbody rb;

    [SerializeField]
    protected NavMeshAgent agent;
    [SerializeField]
    protected BulletPool bulletPool;

    protected Quaternion rotationToShoot;
    protected float FireRate = 4;
    protected float lastfired;

    [SerializeField]
    protected AudioClip shotClip;
    [SerializeField]
    protected AudioSource source;


    [SerializeField]
    protected GameObject gun;

    protected Gun weapon;

    public Gun Weapon
    {
        get { return weapon; }
        set { weapon = value; }
    }
    protected abstract void Shoot();

}
