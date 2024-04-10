using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class Interactor : MonoBehaviour
{

    [SerializeField] Player_SO PlayerSO;



    public static Action<int> batteryCollectedEvent;

    public LayerMask interactionLayer;


    IInteractable interactable;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            interactable = other.gameObject.GetComponent<IInteractable>();
            Debug.Log("yes");
        }
        else
        {
            
            Debug.Log(other.gameObject.layer);
        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            interactable.Interact();
        }
    }


    //if (other.tag == "Battery")
    //{
    //    PlayerSO.batteries += 1;
    //    batteryCollectedEvent?.Invoke(PlayerSO.batteries);
    //    Destroy(other.gameObject);
    //}
}
