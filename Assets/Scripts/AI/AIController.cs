using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : VirtualController
{
    public Transform[] wayPoints;
    public GameObject patrolWaypoints;
    public Transform eyes;
    public float sightRange = 20f;
    public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public NavMeshAgent navMeshAgent;
    public Transform chaseTarget;
    private Vector3 directionToShoot;

    private bool canShoot;
    private float cooldownTime;

    public float FollowAngleOffset
    {
        get
        {
            return followAngleOffset;
        }
        set
        {
            followAngleOffset = (int)value;
        }
    }
    public float CooldownTime
    {
        get
        {
            return cooldownTime;
        }
        set
        {
            cooldownTime = value;
        }
    }
    public bool CanShoot
    {
        get
        {
            return canShoot;
        }
        set
        {
            canShoot = value;
        }
    }

    private AIStateBase currentState;
    private Dictionary<EnemyState, AIStateBase> states;

    private void Awake()
    {
        patrolWaypoints = GameObject.Find("Patrol_Waypoints");
        for (int i = 0; i< wayPoints.Length; i++)
        {
            wayPoints[i] = patrolWaypoints.transform.GetChild(i).transform;
        }
        animationController = this.GetComponent<AnimController>();
        CanShoot = true;
        states = new Dictionary<EnemyState, AIStateBase>();
        states.Add(EnemyState.Patrol, new PatrolState(this));
        states.Add(EnemyState.Alert, new AlertState(this));
        states.Add(EnemyState.Chase, new ChaseState(this));
        states.Add(EnemyState.Shooting, new ShootingState(this));
        Weapon = this.gameObject.GetComponent<Gun>();
        currentState = states[EnemyState.Patrol];
        FireRate = 10;
        cooldownTime = 0.5f;
        animationController = this.GetComponent<AnimController>();
        if(bulletPool == null)
            bulletPool = BulletPool._instance;
        rb = this.GetComponent<Rigidbody>();
        agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        if(!navMeshAgent.isStopped)
        {
            animationController.SetRunningVariable(true);
        }
        else
        {
            animationController.SetRunningVariable(false);
        }
        currentState.UpdateState();
    }

    public void MakeTransition(EnemyState state)
    {
        currentState = states[state];
        currentState.StartState();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    protected override void LookTowardsTarget()
    {
        throw new System.NotImplementedException();
    }
    protected override void MoveTowardsTarget()
    {
        throw new System.NotImplementedException();
    }
    protected override void Shoot()
    {
        weapon.Shoot(directionToShoot);
        AudioSource.PlayClipAtPoint(shotClip, this.transform.position);
        animationController.SetShootingVariable(true);
    }

    public void StopShooting()
    {
        animationController.SetShootingVariable(false);
    }

    public void StopAndShoot(Vector3 _directionToShoot)
    {
        directionToShoot = _directionToShoot;
        Shoot();
    }
    public IEnumerator shootCooldownCR()
    {
        yield return new WaitForSeconds(cooldownTime * Time.deltaTime);
        canShoot = true;
    }
}