//Follow Camera: A camera that follows the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //Add transform for the player
    public Transform player;
    //Target Rotate Speed
    public float targetRotateSpeed;
    //Vector3 for camera
    public Vector3 offset;
    //Player Camera
    private Camera playerCamera;
    //Transform
    private Transform tf;

    
    void Start()
    {
        //Get Components for Camera and Transform.
        playerCamera = GetComponent<Camera>();
        tf = GetComponent<Transform>();
    }
    void Update()
    {
        RotateToMousePosition();
        //Updates the follow player function
        FollowPlayer();
    }

    //Rotate the Mouse Function
    void RotateToMousePosition()

    {
        //Using Unity Plane.
        Plane groundPlane;

        groundPlane = new Plane(Vector3.up, player.position);

        // Find the distance down the ray that the plane intersection is at.
        float distance;
        
        Ray theRay = playerCamera.ScreenPointToRay(Input.mousePosition);

        //Raycast
        if (groundPlane.Raycast(theRay, out distance))
        {
            //Find world point of the intersection.
            Vector3 intersectionPoint = theRay.GetPoint(distance);

            //Rotate towards the intersection point from your mouse pointer.
            Quaternion targetRotation;
            Vector3 lookVector = intersectionPoint - player.position;
            targetRotation = Quaternion.LookRotation(lookVector, Vector3.up);
            player.rotation = Quaternion.RotateTowards(player.rotation, targetRotation, targetRotateSpeed * Time.deltaTime);
        }
    }
    //Follow Player Camera Function
    void FollowPlayer()
    {
        //Updating on the position of the character and camera
        transform.position = player.position + offset;
        tf.position = player.transform.position + offset;
        tf.LookAt(player.position);
    }
}
