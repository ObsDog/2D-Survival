using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMobs : MonoBehaviour
{
    public static KillMobs instance;
    public int health;
    public float radius = 1f;
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        Item speareItem = InventoryManager.instance.GetSelectedItem(false);
        if (speareItem != null && speareItem.action == Item.ActionType.defend && Vector3.Distance(transform.position, player.transform.position) <= radius)
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
