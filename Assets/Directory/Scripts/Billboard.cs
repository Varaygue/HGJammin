using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera theCam;
    void Start()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = theCam.transform.rotation;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, 0f);
    }
}