using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{

    [SerializeField] Player_SO player;
    [SerializeField] private LayerMask layerMask;

    CapsuleCollider cC;
    Light l;

    bool isFlashLightOn;
    public bool hasFlashLight;

    [SerializeField] float maxCharge;
    [SerializeField] float charge;
    [SerializeField] float drainAmount;
    [SerializeField] float batteryChargeAmount;

    private void Start()
    {
        cC = GetComponentInChildren<CapsuleCollider>();
        l = gameObject.GetComponent<Light>();

        l.enabled = false;
        cC.enabled = false;
    }

    private void Update()
    {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMask))
        {
            // Get the direction to the hit point
            Vector3 targetDirection = hit.point - transform.position;
            targetDirection.y = 0f; // Optional: Keep the rotation only in the horizontal plane

            // Rotate towards the hit point
            transform.rotation = Quaternion.LookRotation(targetDirection);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashLight();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UseBattery();
        }

        DrainCharge();
    }

    void ToggleFlashLight()
    {
        if(hasFlashLight)
        {
            if(isFlashLightOn)
            {
                cC.enabled = false;
                l.enabled = false;
                isFlashLightOn = false;
            }
            else if(!isFlashLightOn && charge > 0)
            {
                cC.enabled = true;
                l.enabled = true;
                isFlashLightOn = true;
            }
        }
    }

    void DrainCharge()
    {
        if(isFlashLightOn)
        {
            charge -= drainAmount * Time.deltaTime;
            if(charge <= 0)
            {
                cC.enabled = false;
                l.enabled = false;
                isFlashLightOn = false;
            }
        }


    }

    void UseBattery()
    {
        if(player.batteries > 0)
        {
            charge += batteryChargeAmount;
            player.batteries -= 1;
        }
        
    }
}
