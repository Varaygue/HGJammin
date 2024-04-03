using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
}
