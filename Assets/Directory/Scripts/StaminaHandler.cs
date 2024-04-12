using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaHandler : MonoBehaviour
{
    [SerializeField] Player_SO player;

    [SerializeField] float drainAmount;
    [SerializeField] float recoverAmount;
    
    
    private void OnEnable()
    {
        PlayerController.isSprintingEvent += DepleteStamina;
    }

    private void OnDisable()
    {
        PlayerController.isSprintingEvent -= DepleteStamina;
    }

    
    void Update()
    {
        if(!player.isSprinting && player.stamina < 100)
        {
            RecoverStamina();
        }
    }

    void DepleteStamina()
    {
        player.stamina -= drainAmount * Time.deltaTime;
    }

    void RecoverStamina()
    {
        player.stamina += recoverAmount * Time.deltaTime;
    }
}
