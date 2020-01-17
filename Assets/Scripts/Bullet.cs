using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 5f;

    //Method to move the bullet out of the player barrel, uses rotation to target angle of the mouse around the player.
    public void AccelerateBullet(Quaternion rotationOfPlayer)
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce((rotationOfPlayer* Vector3.forward) * bulletSpeed, ForceMode.Impulse);
    }

    //Method to move the bullet out of the AI barrel, uses position to shoot in the direction of the player.
    public void AccelerateBullet(Vector3 directionOfPlayer)
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce((directionOfPlayer) * bulletSpeed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("boundary"))
        {
                gameObject.SetActive(false);
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            if (other.gameObject.GetComponent<Damageable>().HitPoints >= 0)
            {
                other.gameObject.GetComponent<Damageable>().TakeDamage();
            }
            else
            {
                other.gameObject.GetComponent<Damageable>().Die();
            }
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            this.gameObject.SetActive(false);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            if (other.gameObject.GetComponent<Damageable>().HitPoints >= 0)
            {
                other.gameObject.GetComponent<Damageable>().TakeDamage();
            }
            else
            {
                other.gameObject.GetComponent<Damageable>().Die();
            }
        }
    }
}
