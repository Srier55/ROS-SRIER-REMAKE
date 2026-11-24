
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class InventorySlot
{
    public string itemName;
    public int quantity;
}

public class PlayerInventory : MonoBehaviour
{
    public int maxSlots = 20;

    public List<InventorySlot> items =
        new List<InventorySlot>();

    public bool AddItem(string itemName, int amount)
    {
        if (string.IsNullOrEmpty(itemName) || amount <= 0)
            return false;

        foreach (InventorySlot slot in items)
        {
            if (slot.itemName == itemName)
            {
                slot.quantity += amount;
                return true;
            }
        }

        if (items.Count >= maxSlots)
            return false;

        items.Add(new InventorySlot
        {
            itemName = itemName,
            quantity = amount
        });

        return true;
    }

    public bool RemoveItem(string itemName, int amount)
    {
        if (amount <= 0) return false;

        for (int i = 0; i < items.Count; i++)
        {
            InventorySlot slot = items[i];

            if (slot.itemName == itemName &&
                slot.quantity >= amount)
            {
                slot.quantity -= amount;

                if (slot.quantity == 0)
                    items.RemoveAt(i);

                return true;
            }
        }

        return false;
    }
}
