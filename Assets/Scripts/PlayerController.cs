using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Collections;
using System;

public class PlayerController : VirtualController
{
    //Controls players input and collisions.
    private bool isInside;
    private bool canTeleport;
    private float teleportCooldown;
    private float teleportDistance;
    private ParticleSystem teleportParticleSystem;


    private Vector3 finalClickDestination;
    float angle;



    private List<string> keys;



    [SerializeField]
    private CanvasManager canvasManager;

    void Start()
    {
        canTeleport = true;
        teleportDistance = 5f;
        teleportCooldown = 5f;
        keys = new List<string>(5);
        followAngleOffset = 90;
        MovementSpeed = 2f;
        rb = this.GetComponent<Rigidbody>();
        agent = this.GetComponent<NavMeshAgent>();
        isInside = false;
        animationController = this.GetComponent<AnimController>();
        bulletPool = BulletPool._instance;
        keys.Add("null");
        teleportParticleSystem = this.GetComponent<ParticleSystem>();
        Weapon = this.gameObject.GetComponent<Gun>();
    }


    void Update()
    {
        LookTowardsTarget();
        MoveWithKeys();
        if (this.transform.position.x == finalClickDestination.x && this.transform.position.z == finalClickDestination.z)
        {
            animationController.SetRunningVariable(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Teleport();
        }
        if (Input.GetMouseButton(1))
        {
            if (Time.time - lastfired > 1 / FireRate)
            {
                lastfired = Time.time;
                Shoot();
            }
        }
        else 
        {
            animationController.SetShootingVariable(false);
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animationController.SetRunningVariable(true);
        }
        else
        {
            animationController.SetRunningVariable(false);
        }
    }

    #region Metodos Heredados

    //Turns the player object towards the mouse.
    protected void LookTowardsTarget()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        angle = -(Mathf.Atan2((positionOnScreen.y - mouseOnScreen.y), (positionOnScreen.x - mouseOnScreen.x)) * Mathf.Rad2Deg) - followAngleOffset; //AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
        rotationToShoot = Quaternion.Euler(new Vector3(0f, angle, 0f));

    }

    //Tells the gun to shoot, and plays the animation and sound.
    protected override void Shoot()
    {
        weapon.Shoot(rotationToShoot);
        AudioSource.PlayClipAtPoint(shotClip, this.transform.position);
        animationController.SetShootingVariable(true);
    }

    #endregion
    #region Metodo Propio

    //Method to move through a navMesh using keys.
    void MoveWithKeys()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horInput, 0f, verInput);
        Vector3 moveDestination = transform.position + movement;
        agent.destination = moveDestination;
    }

    //Teleports player forward a set distance, in the direction of the mouse pointer.
    private void Teleport()
    {
        if(canTeleport)
        {
            canTeleport = false;
            canvasManager.teleportCooldownImg.color = new Color(1, 1, 1, 0.4f);
            //Funcionalidad de transportar al muñequito.
            this.transform.Translate(Vector3.forward * teleportDistance);
            teleportParticleSystem.Play();
            agent.destination = this.transform.position;
            StartCoroutine(TeleportCooldownCR());
        }
    }

    private IEnumerator TeleportCooldownCR()
    {
        yield return new WaitForSeconds(teleportCooldown);
        canvasManager.teleportCooldownImg.color = new Color(1, 1, 1, 1);
        canTeleport = true;
    }

    #endregion
    #region Triggers & Collisions
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Inside_Trigger"))
        {
            isInside = true;
        }
        
        if(other.CompareTag("Hide_Inside"))
        {
            if(isInside)
            {
                other.GetComponent<HideObject>().HideObjects();
            }
        }

        if (other.CompareTag("Hide_Both"))
        {
            other.GetComponent<HideObject>().HideObjects();
        }

        if (other.CompareTag("Hide_Outside"))
        {
            if (isInside == false)
            {
                other.GetComponent<HideObject>().HideObjects();
            }
        }

        if(other.CompareTag("key"))
        {
            keys.Add(other.GetComponent<Key>().Value);
            other.GetComponent<Key>().Disapear();
            canvasManager.DisplayInfoText("Encontraste la llave de: " + other.GetComponent<Key>().Value);
        }

        if(other.CompareTag("door"))
        {
            for(int i = 0; i<keys.Count; i++)
            {
                if (keys[i] == other.GetComponent<Door>().LockForKey)
                {
                    other.GetComponent<Door>().OpenDoor();
                    other.GetComponent<Collider>().enabled = false;
                    canvasManager.DisplayInfoText("Open Sesame");
                    keys.Remove(keys[i]);
                }
                else
                {
                    canvasManager.DisplayInfoText("No key for this lock");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Hide_Outside")|| other.CompareTag("Hide_Inside")|| other.CompareTag("Hide_Both"))
        {
            other.GetComponent<HideObject>().ShowObjects();
        }

        if(other.CompareTag("Inside_Trigger"))
        {
            isInside = false;
        }
    }
    #endregion
}
