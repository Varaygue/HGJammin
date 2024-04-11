using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleFollow : MonoBehaviour
{
    public Transform target;

    [SerializeField] float xPosition;
    [SerializeField] float yPosition;
    [SerializeField] float zPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + new Vector3(xPosition, yPosition, zPosition);
    }
}
