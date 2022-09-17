using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] int damage = 10;

    Vector3 startPosition;
    Transform target;
    Animator enemyAnimator;
    NavMeshAgent navMeshAgent;
    EnemyHealth health;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked;
    bool canChase = false;
    CollisionHandler playerCollision;
    
    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        playerCollision = target.GetComponent<CollisionHandler>();

        startPosition = transform.position;

    }

    private void Update()
    {
        SetEnemyIdle();
        CheckPlayerPosition();
    }

    private void SetEnemyIdle()
    {
        float distance = Vector3.Distance(transform.position, startPosition);
        if (distance < 1.5f)
        {
            enemyAnimator.SetBool("move", false);
        }
    }

    private void CheckPlayerPosition()
    {
        if (playerCollision.InBase && isProvoked)
        {
            ResetPosition();
        }
        else if (!playerCollision.InBase)
        {
            canChase = true;
            distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (isProvoked)
            {
                EngageTarget();
            }
            else if (distanceToTarget <= chaseRange && canChase)
            {
                isProvoked = true;
            }
        }
        else if (playerCollision.InBase) canChase = false;
    }

    private void ResetPosition()
    {
        isProvoked = false;
        navMeshAgent.SetDestination(startPosition);
    }

    private void EngageTarget()
    {
        navMeshAgent.enabled = true;
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void ChaseTarget()
    {
        enemyAnimator.SetBool("attack", false);
        enemyAnimator.SetBool("move", true);
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        FaceTarget();
        enemyAnimator.SetBool("attack", true);
    }

    private void FaceTarget()
    {
        Vector3 distance = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(distance.x, 0f, distance.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
