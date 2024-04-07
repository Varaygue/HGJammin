using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    public SpriteRenderer sr;
    public InputActionReference move;
    public LayerMask terrainLayer;
    CharacterController characterController;

    public Vector3 moveDir;
    public float speed;
    public float groundDist;
    

    private float gravity = -9.81f;
    [SerializeField] float gravityMultiplier = 3.0f;
    private float velocity;


    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

   
    void Update()
    {

        ApplyMovement();
        ApplyFacingDirection();
        
    }

    void ApplyMovement()
    {
        moveDir = move.action.ReadValue<Vector2>();

        moveDir = new Vector3(moveDir.x, 0, moveDir.y).normalized;
        ApplyGravity(); // needs to be here
        characterController.Move(moveDir * speed * Time.deltaTime);
    }

    void ApplyFacingDirection()
    {
        if (moveDir.x != 0 && moveDir.x < 0)
        {
            sr.flipX = true;
        }
        else if (moveDir.x != 0 && moveDir.x > 0)
        {
            sr.flipX = false;
        }
    }

    void ApplyGravity()
    {
        if (characterController.isGrounded && velocity < 0.0f)
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }

        moveDir.y = velocity;
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
