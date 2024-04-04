using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        Transform camTransform = Camera.main.transform;
        transform.forward = camTransform.forward;
    }
}
