using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwardsBillboard : MonoBehaviour
{
    private Camera mainCamera;

    public Transform player;
    private SpriteRenderer sr;
    void Start()
    {
        mainCamera = Camera.main;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (mainCamera != null)
        {
            switchBillboard();
        }
        
    }

    void switchBillboard()
    {

        if(transform.position.z < player.position.z)
        {
            transform.LookAt(Camera.main.transform, Vector3.up);
            if(sr.flipX == true)
            {
                sr.flipX = false;
            }
        }
        else
        {
            Vector3 lookDir = mainCamera.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(-lookDir, Vector3.up);
            transform.rotation = targetRotation;

            if (sr.flipX == false)
            {
                sr.flipX = true;
            }
        }
    }
    
}

