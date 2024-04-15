using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    private KeyCode pickUpKey = KeyCode.E;

    private bool isPickedUp = false;

    private void OnTriggerStay2D(Collider2D other)
    {   
        if (Input.GetKeyDown(pickUpKey) && !isPickedUp)
        {
            bool canAdd = InventoryManager.instance.AddItem(item);
            if (canAdd)
            {
                isPickedUp = true;
                Destroy(gameObject);
            }
        }
    }
}