using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour, ICollectable
{

    public Item item;
    public int amount;

    public void Collect()
    {
        InventorySystem inventorySystem = InventorySystem.Instance;
        List<SlotItem> itemList = inventorySystem.itemList;

        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].item._name == this.item._name && itemList[i].stackCount + this.amount <= itemList[i].maxStackCount)
            {
                itemList[i].stackCount += amount;
                inventorySystem.Add(itemList[i]);
                Destroy(gameObject);

            }
            else if (itemList[i].item._name == this.item._name && itemList[i].stackCount + this.amount > itemList[i].maxStackCount)
            {
                int deficit = ((itemList[i].stackCount + this.amount) - this.item._maxStackCount);
                itemList[i].stackCount += amount - deficit;
                inventorySystem.Add(itemList[i]);
                this.amount = deficit;
            }
            else if (itemList.Count < inventorySystem._maxSlot)
            {
                inventorySystem.Add(new SlotItem(item,amount,item._maxStackCount));
            }
        }
    }
}

