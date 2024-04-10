using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Battery : MonoBehaviour, IInteractable
{
    public Player_SO PlayerSO;

    public static Action<int> batteryCollectedEvent;
    public void Interact()
    {
        PlayerSO.batteries += 1;
        batteryCollectedEvent?.Invoke(PlayerSO.batteries);
        Destroy(gameObject);
    }
}
