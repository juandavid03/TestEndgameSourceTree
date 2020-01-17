using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    //Class in charge of the firing of the bullets.
    [SerializeField]
    private GameObject gun;

    //Fires the bullets of the Player, has a quaternion (rotation) to get the angle between the mouse to the player's base angle.
    public void Shoot(Quaternion rotationToShoot)
    {
        GameObject bullet = BulletPool._instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = gun.transform.position;
            bullet.transform.rotation = gun.transform.rotation;
            bullet.SetActive(true);

            bullet.GetComponent<Bullet>().AccelerateBullet(rotationToShoot);
        }
    }

    //Fires the bullets of the AI, has a vector3 (postion) to shoot in the direction of the player.
    public void Shoot(Vector3 directionToShoot)
    {
        GameObject bullet = BulletPool._instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = gun.transform.position;
            bullet.transform.rotation = gun.transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().AccelerateBullet(directionToShoot);
        }
    }
}
