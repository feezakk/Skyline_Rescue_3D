using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform plane;            // Reference to the plane object
    public Vector3 offset = new Vector3(0, 5, -10); // Adjust as needed to position behind the plane

    void LateUpdate()
    {
        // Directly set the camera position without smoothing
        transform.position = plane.position + offset;

        // Make the camera look slightly downward to see the plane
        transform.LookAt(plane.position + Vector3.up * 2);
    }
}
