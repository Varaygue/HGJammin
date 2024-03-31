using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    SpriteRenderer sr;

    public LayerMask terrainLayer;

    public float groundDist;
    public float speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
    }

   
    void LateUpdate()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
       
        Vector3 moveDir = new Vector3(x, 0, y).normalized;
        rb.velocity = moveDir * speed;
        
        if (x != 0 && x < 0)
        {
            sr.flipX = true;
        }  
        else if (x != 0 && x > 0)
        {
            sr.flipX = false;
        }
        
    }
}
