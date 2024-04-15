using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5f; // Enemy movement speed
    public float detectionRange = 5f; // Range at which enemy can detect player
    public float attackRange = 1f; // Range at which enemy can attack player
    public float damage = 10f; // Damage dealt by enemy
    public float attackDelay = 2f; // Time between enemy attacks

    private Transform player;
    private bool isAttacking;
    private float attackTimer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find player object
    }

    private void Update()
    {
        if (player == null) return; // If player object is destroyed, stop updating

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < detectionRange) // If player is within detection range
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime; // Move towards player

            if (distance < attackRange) // If player is within attack range
            {
                Attack(); // Attack player
            }
        }
    }

    private void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            player.GetComponent<Survival>().PlayerHealth(damage); // Deal damage to player
            attackTimer = attackDelay;
        }
        else
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                isAttacking = false;
            }
        }
    }
}

