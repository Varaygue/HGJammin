using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Light")
        {
            gameObject.GetComponent<Light>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Light")
        {
            gameObject.GetComponent<Light>().enabled = false;
        }
    }
}
