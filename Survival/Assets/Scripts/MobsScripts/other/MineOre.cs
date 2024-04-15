using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineOre : MonoBehaviour
{
    public static MineOre instance;
    public GameObject StonePrefab;
    public int health;
    public float radius = 1f;
    public Animator animator;
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

    public void Shake()
    {
        animator.SetTrigger("ShakeOre");
    }

    public void TakeDamage()
    {
        Item pickaxeItem = InventoryManager.instance.GetSelectedItem(false);
        if (pickaxeItem != null && pickaxeItem.action == Item.ActionType.mine && Vector3.Distance(transform.position, player.transform.position) <= radius)
        {
            Shake();
            health--;
            if (health <= 0)
            {
                Instantiate(StonePrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
