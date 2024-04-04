using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        // Face the camera
        transform.LookAt(Camera.main.transform, Vector3.up);
    }
}
