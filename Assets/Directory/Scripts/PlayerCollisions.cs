using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class PlayerCollisions : MonoBehaviour
{

    [SerializeField] Player_SO PlayerSO;



    public static Action<int> batteryCollectedEvent;

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Battery")
        {
            PlayerSO.batteries += 1;
            batteryCollectedEvent?.Invoke(PlayerSO.batteries);
            Destroy(other.gameObject);
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    void Interatable(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {

        }
    }
}
