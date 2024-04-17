using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    public SpriteRenderer[] sr;
    public InputActionReference move;
    public InputActionReference run;
    public LayerMask terrainLayer;
    CharacterController characterController;

    public Vector3 moveDir;
    public float speed;
    private float groundDist;
    
    private float gravity = -9.81f;
    [SerializeField] float gravityMultiplier = 3.0f;
    private float velocity;

    public bool isSprinting;
    public float sprintSpeed;

    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        sr = GetComponentsInChildren<SpriteRenderer>();
    }

   
    void Update()
    {

        ApplyMovement();
        ApplyFacingDirection();
        
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        isSprinting = context.started || context.performed;
    }

    void ApplyMovement()
    {
        moveDir = move.action.ReadValue<Vector2>();
        
        if(isSprinting)
        {
            moveDir = new Vector3(moveDir.x * sprintSpeed, 0, moveDir.y * sprintSpeed);
        }
        else
        {
            moveDir = new Vector3(moveDir.x * speed, 0, moveDir.y * speed);
        }
        
        ApplyGravity(); // needs to be here
        characterController.Move(moveDir * Time.deltaTime);
    }

    void ApplyFacingDirection()
    {
        if (moveDir.x != 0 && moveDir.x < 0)
        {
            //sr.flipX = true;
            foreach (SpriteRenderer spriteRenderer in sr)
            {
                spriteRenderer.flipX = true;
            }
        }
        else if (moveDir.x != 0 && moveDir.x > 0)
        {
            //sr.flipX = false;
            foreach (SpriteRenderer spriteRenderer in sr)
            {
                spriteRenderer.flipX = false;
            }
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
