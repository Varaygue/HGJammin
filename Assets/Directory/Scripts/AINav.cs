using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AINav : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;

    public bool seesPlayer;

    [SerializeField] Vector3 rayPositionOffset;

    public LayerMask ignoreLayer;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

   
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
            Vector3 direction = other.transform.position - gameObject.transform.position - rayPositionOffset + new Vector3(0,0, 1.12f);
            Ray ray = new Ray(gameObject.transform.position + rayPositionOffset, direction);
            RaycastHit hit;
            Debug.DrawRay(gameObject.transform.position + rayPositionOffset, direction, Color.green);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ~ignoreLayer))
            {
               if(hit.collider.gameObject.CompareTag("Player") || hit.collider.gameObject.CompareTag("Light"))
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
