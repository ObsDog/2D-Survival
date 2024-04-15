using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ChopTree : MonoBehaviour
{
    public static ChopTree instance;
    public GameObject logPrefab;
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
        animator.SetTrigger("Shake");
    }

    public void TakeDamage()
    {
        Item axeItem = InventoryManager.instance.GetSelectedItem(false);
        if (axeItem != null && axeItem.action == Item.ActionType.chop && Vector3.Distance(transform.position, player.transform.position) <= radius)
        { 
            Shake();
            health--;
            if (health <= 0)
            {
                Instantiate(logPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
