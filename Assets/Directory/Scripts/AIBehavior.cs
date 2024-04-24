using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AINav))]
public class AIBehavior : MonoBehaviour
{
    AINav aINav;
    NavMeshAgent navMeshAgent;
    SpriteRenderer[] sr;

    [SerializeField] float chaseSpeed;
    [SerializeField] float patrolSpeed;
    [SerializeField] float chargeSpeed;


    [SerializeField] float stamina;
    [SerializeField] float drainRate;
    [SerializeField] float recoveryRate;

    bool isCharging;

    void Start()
    {
        aINav = gameObject.GetComponent<AINav>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        sr = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    
    void Update()
    {
        if(aINav.seesPlayer)
        {
            if(isCharging)
            {
                ChargeAtPlayer();
                DrainStamina();
            }
            else
            {
                GiveChase();
            }
        }
        else
        {
            Patrol();
        }

        if(!isCharging)
        {
            RecoverStamina();
        }

        FlipSprite();
    }

    void GiveChase()
    {
        navMeshAgent.speed = chaseSpeed;
    }

    void ChargeAtPlayer()
    {
        navMeshAgent.speed = chargeSpeed;

        
    }

    void Patrol()
    {
        navMeshAgent.speed = patrolSpeed;
    }

    void DrainStamina()
    {
        if (stamina > 0)
        {
            stamina -= drainRate * Time.deltaTime;
        }
        else
        {
            isCharging = false;
        }
    }

    void RecoverStamina()
    {
        if(stamina < 100)
        {
            stamina += recoveryRate * Time.deltaTime;
        }
        else
        {
            isCharging = true;
        }
        
    }


    void FlipSprite()
    {
        if (navMeshAgent.velocity.x > 0.1f)
        {
            foreach (SpriteRenderer spriteRenderer in sr)
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (navMeshAgent.velocity.x < -0.1f)
        {
            foreach (SpriteRenderer spriteRenderer in sr)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}
