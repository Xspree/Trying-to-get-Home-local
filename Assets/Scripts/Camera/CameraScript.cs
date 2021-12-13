using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private Transform player1;

    [SerializeField]
    private Transform player2;


    
    // Update is called once per frame
    void LateUpdate()
    {
        FixedCameraFollowSmooth(cam, player1, player2);
    }

    private void FixedCameraFollowSmooth(Camera camera, Transform player1, Transform player2)
    {
        float zoomFactor = 4f;
        float followTimeDelta = 0.1f;

        // Midpoint we're after
        Vector3 midpoint = (player1.position + player2.position) / 2f;

        // Distance between objects
        float distance = (player1.position - player2.position).magnitude;
        if(distance >= 16f)
        {
            distance = 16f;
        }
        //Debug.Log(distance + "player distance");
        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;
        //Debug.Log(cameraDestination + " CD");
        

        /*// Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = distance;
        }*/
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;
    }
}
