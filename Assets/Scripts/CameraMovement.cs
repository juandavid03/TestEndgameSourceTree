using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform objectToFollow;

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
    }

    //Follow the player around.
    private void LookAtTarget()
    {
        this.transform.position = new Vector3(objectToFollow.transform.position.x, this.transform.position.y, objectToFollow.transform.position.z);
    }
}
