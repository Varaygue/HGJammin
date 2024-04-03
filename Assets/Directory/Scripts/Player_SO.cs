using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/Player")]
public class Player_SO : ScriptableObject
{
    public float progression;
    public float batteries;



    void OnEnable()
    {
        progression = 0;
        batteries = 0;
    }
    
}
