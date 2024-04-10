using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class Interactor : MonoBehaviour
{

    [SerializeField] Player_SO PlayerSO;



    

    public LayerMask interactionLayer;


    IInteractable interactable;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            interactable = other.gameObject.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactable = null;
        Debug.Log("yo");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactable?.Interact();
        }
    }

    private void OnEnable()
    {
        Battery.batteryCollectedEvent += RemoveInteractable;
    }

    private void OnDisable()
    {
        Battery.batteryCollectedEvent -= RemoveInteractable;
    }

    void RemoveInteractable(int x)
    {
        interactable = null;
    }

   
}
