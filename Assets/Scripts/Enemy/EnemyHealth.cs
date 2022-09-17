using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField][Range(0,1)] float dropChance;
    [SerializeField] GameObject[] pickUpBonuses;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnEnemyDeath();
        }
    }

    public void OnEnemyDeath()
    {
        if (Random.Range(0f, 1f) <= dropChance)
        {
            GameObject selectedObject = pickUpBonuses[Random.Range(0, pickUpBonuses.Length)];
            Instantiate(selectedObject, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(other.gameObject.GetComponentInParent<PlayerAttack>().PlayerDamage);
    }
}
