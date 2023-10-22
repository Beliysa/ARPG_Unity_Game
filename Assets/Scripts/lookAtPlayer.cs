using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    public Transform cam;

    // Update is called once per frame
    void LateUpdate()
    {
        //called after the update method because we want to update health bar position and orientation after we change the camera position after we look around with the mouse
        transform.LookAt(cam);
    }
}
