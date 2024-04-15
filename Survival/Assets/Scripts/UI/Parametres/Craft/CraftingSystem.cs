using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    [SerializeField] private Item craftedItem; // предмет, который мы можем создать
    [SerializeField] private List<Item> requiredItems; // список необходимых для крафта предметов

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = InventoryManager.instance;
    }

    public void CraftItem()
    {
        bool canCraft = requiredItems.All(requiredItem =>
            inventoryManager.inventorySlots.Any(slot =>
                slot.GetComponentInChildren<InventoryItem>() is InventoryItem itemInSlot &&
                itemInSlot.item == requiredItem &&
                itemInSlot.count >= 1
            )
        );

        if (canCraft)
        {
            // удаляем необходимые для крафта предметы из инвентаря игрока
            foreach (Item requiredItem in requiredItems)
            {
                InventorySlot slotWithItem = inventoryManager.inventorySlots.FirstOrDefault(slot =>
                    slot.GetComponentInChildren<InventoryItem>() is InventoryItem itemInSlot &&
                    itemInSlot.item == requiredItem &&
                    itemInSlot.count >= 1
                );

                if (slotWithItem != null)
                {
                    InventoryItem itemInSlot = slotWithItem.GetComponentInChildren<InventoryItem>();
                    itemInSlot.count--;
                    if (itemInSlot.count <= 0)
                    {
                        Destroy(itemInSlot.gameObject);
                    }
                    else
                    {
                        itemInSlot.RefreshCoint();
                    }
                }
                else
                {
                    Debug.Log("Something went wrong, required item not found!");
                    return;
                }
            }

            // добавляем новый предмет в инвентарь игрока
            inventoryManager.AddItem(craftedItem);
        }
        else
        {
            Debug.Log("You don't have all the required items to craft this item!");
        }
    }
}

