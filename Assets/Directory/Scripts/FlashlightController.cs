using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
   

    private Light spotlight;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        spotlight = GetComponent<Light>();

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
    }
}
