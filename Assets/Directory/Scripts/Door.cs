using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Transform doorTransform;

    Vector3 doorNormal;
    Vector3 doorToObject;
    float dotProduct;

    public bool isOpen;

    Transform playerTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerTransform = other.gameObject.transform;
        }
    }


    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        if (dotProduct > 0)
    //        {
    //            doorTransform.Rotate(0, -90, 0);
    //        }
    //        else if (dotProduct < 0)
    //        {
    //            doorTransform.Rotate(0, 90, 0);
    //        }
    //        else
    //        {

    //        }
    //    }

    //}

    public void Interact()
    {
        doorNormal = transform.forward;
        doorToObject = playerTransform.position - transform.position;

        dotProduct = Vector3.Dot(doorNormal, doorToObject);

        if (!isOpen)
        {
            if (dotProduct > 0)
            {
                doorTransform.Rotate(0, 90, 0);
            }
            else
            {
                doorTransform.Rotate(0, -90, 0);
            }
            isOpen = true;
        }
        else
        {
            if (dotProduct > 0)
            {
                doorTransform.Rotate(0, -90, 0);
            }
            else
            {
                doorTransform.Rotate(0, 90, 0);
            }
            isOpen = false;
        }

    }


}
