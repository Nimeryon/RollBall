using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private float xRotation = .2f;
    [SerializeField] private float zRotation = .2f;
    [SerializeField] private float speed = 10f;
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float hSpd = vertical * speed * Time.deltaTime;
        float vSpd = -horizontal * speed * Time.deltaTime;

        Vector3 euler = transform.localEulerAngles;
        if (hSpd < 0 && WrapAngle(euler.x) > -xRotation)
            transform.Rotate(Vector3.right, hSpd);
    
        if (hSpd > 0 && WrapAngle(euler.x) < xRotation)
            transform.Rotate(Vector3.right, hSpd);
        
        if (vSpd < 0 && WrapAngle(euler.z) > -zRotation)
            transform.Rotate(Vector3.forward, vSpd);
        
        if (vSpd > 0 && WrapAngle(euler.z) < zRotation)
            transform.Rotate(Vector3.forward, vSpd);

        // Reset y rotation
        transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w));
    }

    private static float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }
}
