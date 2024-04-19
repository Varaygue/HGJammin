using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AINav : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;
    }
}
