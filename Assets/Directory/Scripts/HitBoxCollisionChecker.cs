using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxCollisionChecker : MonoBehaviour
{
    IDamager damager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hitbox"))
        {
            Debug.Log("damage taken");
            damager = other.gameObject.GetComponent<IDamager>();
            damager.DoDamage();
        }
    }
}
