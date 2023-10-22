using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{

    public Transform cam;

    // Update is called once per frame
    void LateUpdate()
    {
        //so after the camera moved we turn towards it
        transform.LookAt(transform.position + cam.forward); //points the billboard in the same direction as our camera
        //will take our position and will go one unit in the direction that the camera is currently facing and that will be the target we look for
    }
}
