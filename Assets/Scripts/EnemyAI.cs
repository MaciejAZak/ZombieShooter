using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    Rigidbody rigidBody;
    float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, this.transform.position);
        if (distanceToTarget < chaseRange)
        {
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            // Debug.Log("Not chasing");
        }
    }
}
