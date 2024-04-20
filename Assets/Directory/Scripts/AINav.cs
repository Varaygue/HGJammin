using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AINav : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;

    bool seesPlayer;

    [SerializeField] Vector3 rayPositionOffset;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(seesPlayer)
        {
            navMeshAgent.destination = movePositionTransform.position;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Vector3 direction = other.transform.position - gameObject.transform.position - rayPositionOffset;
            Ray ray = new Ray(gameObject.transform.position + rayPositionOffset, direction);
            RaycastHit hit;
            Debug.DrawRay(gameObject.transform.position + rayPositionOffset, direction, Color.green);
            if(Physics.Raycast(ray, out hit))
            {
               if(hit.collider.gameObject.CompareTag("Player"))
                {
                    seesPlayer = true;
                }
               else
                {
                    seesPlayer = false;
                }
               
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        seesPlayer = false;
    }
}
