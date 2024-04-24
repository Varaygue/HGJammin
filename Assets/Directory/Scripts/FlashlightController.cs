using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
   

    private Light spotlight;
    [SerializeField] private LayerMask layerMask;

    CapsuleCollider cC;
    Light l;

    bool isFlashLightOn;
    public bool hasFlashLight;

    private void Start()
    {
        spotlight = GetComponent<Light>();
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
            else
            {
                cC.enabled = true;
                l.enabled = true;
                isFlashLightOn = true;
            }
        }
    }
}
