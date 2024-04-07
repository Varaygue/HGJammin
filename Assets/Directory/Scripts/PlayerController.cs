using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public SpriteRenderer sr;

    public InputActionReference move;

    public LayerMask terrainLayer;
    
    Vector3 moveDir;

    public float groundDist;
    public float speed;

    CharacterController cc;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
    }

   
    void Update()
    {
        moveDir = move.action.ReadValue<Vector2>();

        //moveDir = new Vector3(moveDir.x, 0, moveDir.y).normalized;
        //cc.Move(moveDir * speed * Time.deltaTime);
        
        rb.velocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.z * speed);
        

        if (moveDir.x != 0 && moveDir.x < 0)
        {
            sr.flipX = true;
        }  
        else if (moveDir.x != 0 && moveDir.x > 0)
        {
            sr.flipX = false;
        }
        
    }

    void groundPosition()
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
    }
}
