using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorTransform;

    Vector3 doorNormal;
    Vector3 doorToObject;
    float dotProduct;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("nothing");
            doorNormal = transform.forward;
            doorToObject = other.transform.position - transform.position;

            dotProduct = Vector3.Dot(doorNormal, doorToObject);

            if (dotProduct > 0)
            {
                doorTransform.Rotate(0, 90, 0);
            }
            else if (dotProduct < 0)
            {
                doorTransform.Rotate(0, -90, 0);
            }
            else
            {
               
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if (dotProduct > 0)
            {
                doorTransform.Rotate(0, -90, 0);
            }
            else if (dotProduct < 0)
            {
                doorTransform.Rotate(0, 90, 0);
            }
            else
            {

            }
        }
        
    }


}
