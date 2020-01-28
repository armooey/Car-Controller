using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed = 10;
    public float roatationSpeed = 20;

    public void LookAt()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, roatationSpeed * Time.deltaTime);
    }

    public void MoveTo()
    {
        Vector3 position = target.position + target.forward * offset.z
                                           + target.right * offset.x
                                           + target.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        LookAt();
        MoveTo();
    }
}
