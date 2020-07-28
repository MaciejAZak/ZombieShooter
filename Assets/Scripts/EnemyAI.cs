using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 15f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    Rigidbody rigidBody;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, this.transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance && distanceToTarget >= 10)
        {
            ChaseTarget();
        }
        else if (distanceToTarget >= navMeshAgent.stoppingDistance && distanceToTarget < 10)
        {
            ChaseTargetFaster();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        GetComponentInChildren<Animator>().SetBool("Attack", true);
        Debug.Log("Attacked!");
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void ChaseTarget()
    {
        GetComponentInChildren<Animator>().SetBool("Attack", false);
        GetComponentInChildren<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void ChaseTargetFaster()
    {
        GetComponentInChildren<Animator>().SetBool("Attack", false);
        GetComponentInChildren<Animator>().SetTrigger("fastmove");
        navMeshAgent.SetDestination(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

    }
}
