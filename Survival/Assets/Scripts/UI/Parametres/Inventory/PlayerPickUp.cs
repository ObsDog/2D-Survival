using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private InventoryManager inventoryManager;
    public Item item;
    private float pickupRadius = 0.5f;
    private Transform player;

    private void Start()
    {
        inventoryManager = InventoryManager.instance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (item != null && Vector3.Distance(transform.position, player.transform.position) < pickupRadius)
            {
                bool canAdd = inventoryManager.AddItem(item);
                if (canAdd)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

