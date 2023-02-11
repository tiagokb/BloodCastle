using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Quaternion rotation;

    // Update is called once per frame
    void Update()
    {
     
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, rotation, smoothSpeed);
        transform.position = smoothedPosition;
        transform.rotation = smoothedRotation;
    }
}
