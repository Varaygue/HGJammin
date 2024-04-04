using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwardsBillboard : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        
            if (mainCamera != null)
            {
            // Calculate the direction to the camera
            Vector3 lookDir = mainCamera.transform.position - transform.position;

            // Calculate the rotation needed to look at the camera
            Quaternion targetRotation = Quaternion.LookRotation(-lookDir, Vector3.up);

            // Apply the rotation to the object
            transform.rotation = targetRotation;
        }
        
    }
}

