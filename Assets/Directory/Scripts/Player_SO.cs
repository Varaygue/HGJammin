using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/Player")]
public class Player_SO : ScriptableObject
{
    public float Health;
    public int batteries;



    void OnEnable()
    {
        Health = 100;
        Debug.Log(Health);
        batteries = 0;
    }
    
}
