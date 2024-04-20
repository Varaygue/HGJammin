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

    [SerializeField] float chaseSpeed;
    [SerializeField] float patrolSpeed;
    [SerializeField] float chargeSpeed;


    [SerializeField] float stamina;
    [SerializeField] float drainRate;
    [SerializeField] float recoveryRate;

    bool isRecovering;
    bool isCharging;

    void Start()
    {
        aINav = gameObject.GetComponent<AINav>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
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
}
