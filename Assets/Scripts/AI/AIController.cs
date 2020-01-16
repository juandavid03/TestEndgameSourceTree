using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : VirtualController
{
    public Transform[] wayPoints;
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

    public float HitPoints
    {
        get { return hitPoints; }
    }
    private void Awake()
    {
        hitPoints = 1f;
        animationController = this.GetComponent<AnimController>();
        CanShoot = true;
        states = new Dictionary<EnemyState, AIStateBase>();
        states.Add(EnemyState.Patrol, new PatrolState(this));
        states.Add(EnemyState.Alert, new AlertState(this));
        states.Add(EnemyState.Chase, new ChaseState(this));
        states.Add(EnemyState.Shooting, new ShootingState(this));
        currentState = states[EnemyState.Patrol];
        FireRate = 10;
        cooldownTime = 0.5f;
        animationController = this.GetComponent<AnimController>();
        bulletPool = GameManager._instance.GetComponent<BulletPool>();
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
        Debug.LogError("Current State: " + currentState);
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
        animationController.SetShootingVariable(true);
        GameObject bullet = bulletPool.GetPooledObject();
        if (bullet != null)
        {
                bullet.transform.position = gun.transform.position;
                bullet.transform.rotation = gun.transform.rotation;
                AudioSource.PlayClipAtPoint(shotClip, this.transform.position);
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().AccelerateBullet(directionToShoot);
        }
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
    public override void TakeDamage()
    {
        hitPoints -= 0.25f;
    }
    protected override void Die()
    {
        this.gameObject.SetActive(false);
    }

    public void DiePublic()
    {
        Die();
    }

    public IEnumerator shootCooldownCR()
    {
        yield return new WaitForSeconds(cooldownTime * Time.deltaTime);
        canShoot = true;
    }
}