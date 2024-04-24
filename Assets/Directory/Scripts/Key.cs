using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Key : MonoBehaviour, IInteractable
{
    public Player_SO PlayerSO;

    public static Action<int> keyCollectedEvent;
    public void Interact()
    {
        PlayerSO.keys += 1;
        keyCollectedEvent?.Invoke(PlayerSO.batteries);
        Destroy(gameObject);
    }
}
