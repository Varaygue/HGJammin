using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Transform doorTransform;

    //Vector3 doorNormal;
    //Vector3 doorToObject;
    //float dotProduct;

    public bool isOpen;

    //Transform playerTransform;

    public void Interact()
    {
        if (!isOpen)
        {
            doorTransform.Rotate(0, -90, 0);
            isOpen = true;
        }
        else
        {
            doorTransform.Rotate(0, 90, 0);
            isOpen = false;
        }
    }


}
