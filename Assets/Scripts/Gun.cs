using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject gun;
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
