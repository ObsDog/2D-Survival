using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleeCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Item attackItem = InventoryManager.instance.GetSelectedItem(false);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            if(attackItem != null && attackItem.action == Item.ActionType.defend)
            {
                enemy.GetComponent<EnemyBehaivour>().TakeDamage(attackItem.attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
