using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public int maxStackedItems = 10;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    private Transform player;
    private Survival survival;

    public int selectedSlot = -1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeSelectedSlot(0);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        survival = (Survival)FindObjectOfType(typeof(Survival));
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropSelectedItem();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ReceivedSelectedItem();
        }

        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 8)
            {
                ChangeSelectedSlot(number - 1);
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            int newValue = selectedSlot + (int)(scroll / Mathf.Abs(scroll));
            if (newValue < 0)
            {
                newValue = inventorySlots.Length - 1;
            }
            else if (newValue >= inventorySlots.Length) 
            {
                newValue = 0;
            }
            ChangeSelectedSlot(newValue);
        }
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }

        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Item item)
    {

        //Check if any slot has the same item with count lower than max
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null &&
                itemInSlot.item == item &&
                itemInSlot.count < maxStackedItems &&
                itemInSlot.item.stackable == true)
            {

                itemInSlot.count++;
                itemInSlot.RefreshCoint();
                return true;
            }
        }

        //Find any empty slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlots = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlots == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }


    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public void DropSelectedItem()
    {
        Item selectedItem = GetSelectedItem(false);
        if (selectedItem != null)
        {
            Vector2 dropPosition = new Vector2(player.position.x, player.position.y + 1);
            Instantiate(selectedItem.dropPrefab, dropPosition, Quaternion.identity);
            GetSelectedItem(true);
        }
    }
    public void ReceivedSelectedItem()
    {
        Item selectedItem = GetSelectedItem(false);
        if (selectedItem != null && selectedItem.action == Item.ActionType.feed)
        {
            survival.Hunger += selectedItem.hungerAmount;
            GetSelectedItem(true);

        }
        else if (selectedItem != null && selectedItem.action == Item.ActionType.drink)
        {
            survival.Thirst += selectedItem.thirstAmount;
            GetSelectedItem(true);
        }
    }

    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use == true)
            {
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

            return item;
        }
        return null;
    }
}
