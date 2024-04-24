using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform exitPortal;
    [SerializeField] Player_SO player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.canMove = false;
            Debug.Log("it not working");
            other.gameObject.transform.position = exitPortal.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player.canMove = true;
    }
}
