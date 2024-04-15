using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaivour : MonoBehaviour
{
    public Animator animator;
    public float maxHealth = 100f;
    float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth >= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
    }
}
