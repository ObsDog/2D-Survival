using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerAndThirst : MonoBehaviour
{
    public float hunger;
    public int thirst;
    private Item item;
    private Survival survival;

    public void OnMouseDown()
    {
        if (item.action == Item.ActionType.feed)
        {
            if (Input.GetMouseButtonDown(1) && InventoryManager.instance.GetSelectedItem(true))
            {
                hunger += survival.Hunger;
            }
        }
    }
}
