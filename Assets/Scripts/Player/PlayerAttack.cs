using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float playerRange = 15f;
    [SerializeField] Transform weapon;

    [SerializeField] int playerDamage = 10;
    public int PlayerDamage { get { return playerDamage; } }

    float attackRate = 3f;
    public float AttackRate { get { return attackRate; } set { attackRate = value; } }

    EnemyAI[] enemies;
    Transform target;
    ParticleSystem projectileParticles;

    private void Start()
    {
        projectileParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        FindClosestTarget();
        Aim();
    }

    private void FindClosestTarget()
    {
        enemies = FindObjectsOfType<EnemyAI>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (EnemyAI enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    private void Aim()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if (targetDistance < playerRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    private void Attack(bool isActive)
    {
        projectileParticles.gameObject.SetActive(isActive);
    }
}
