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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        doorNormal = transform.forward;
    //        doorToObject = other.transform.position - transform.position;

    //        dotProduct = Vector3.Dot(doorNormal, doorToObject);
    //    }
    //}


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
        Debug.Log("open");
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
        }

    }


}
