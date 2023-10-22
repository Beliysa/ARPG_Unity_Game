using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; //will be the target to follow

    public Vector3 offset; //will be the camera's offset from the target

    private float currentZoom = 10f;
    private float currentYaw = 0f;
    
    public float pitch = 1f;
    public float zoomSpeed = 4f;
    public float maxZoom = 15f;
    public float minZoom = 5f;
    public float yawSpeed = 100f; //for the rotation of our camera

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom); //we want to clamp our zoom between min and max
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;//we use -= to offset it directly
    }

    void LateUpdate()
    {
        //this method is like the update method but it is called right after
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up, currentYaw);//the angle is currentYaw
    }
}
