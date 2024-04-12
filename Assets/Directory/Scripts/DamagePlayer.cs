using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour, IDamager
{
    [SerializeField] private Player_SO player;

    [SerializeField] float damageAmount;

    public void DoDamage()
    {
        player.Health -= damageAmount;
        Debug.Log(player.Health);
    }
}
