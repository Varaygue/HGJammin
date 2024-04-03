using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    [SerializeField] Player_SO PlayerSO;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Battery")
        {
            PlayerSO.batteries += 1;
            Destroy(other.gameObject);
        }
    }
}
