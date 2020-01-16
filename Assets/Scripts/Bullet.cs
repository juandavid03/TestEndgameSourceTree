using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 5f;
    public void AccelerateBullet(Quaternion rotationOfPlayer)
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce((rotationOfPlayer* Vector3.forward) * bulletSpeed, ForceMode.Impulse);
    }
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
            if (other.gameObject.GetComponent<PlayerController>().HitPoints >= 0)
            {
                other.gameObject.GetComponent<PlayerController>().TakeDamage();
            }
            else
            {
                other.gameObject.GetComponent<PlayerController>().DiePublic();
            }
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            this.gameObject.SetActive(false);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            if (other.gameObject.GetComponent<AIController>().HitPoints >= 0)
            {
                other.gameObject.GetComponent<AIController>().TakeDamage();
            }
            else
            {
                other.gameObject.GetComponent<AIController>().DiePublic();
            }
        }
    }
}
