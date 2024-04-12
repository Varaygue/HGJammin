using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/Player")]
public class Player_SO : ScriptableObject
{
    public float health;
    public int batteries;
    public bool isSprinting;
    public float stamina = 100;
    // conditionState



    void OnEnable()
    {
        health = 100;
        Debug.Log(health);
        batteries = 0;
        stamina = 100;
    }
    
}
