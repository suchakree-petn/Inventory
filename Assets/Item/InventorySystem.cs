using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;
    void Awake()
    {
        Instance = this;
    }

    public List<SlotItem> itemList = new List<SlotItem>();
    public int _maxSlot;

    public void Add(SlotItem slotItem)
    {
        for(int i = 0;i<itemList.Count;i++)
        {
            if (itemList[i].item == slotItem.item)
            {
                itemList[i] = slotItem;
                return;
            }
        }
        itemList.Add(slotItem);
    }
    public void Remove(Item item, int amount)
    {
        foreach (SlotItem slot in itemList)
        {
            if (slot.item == item)
            {
                if (slot.maxStackCount > amount)
                {
                    slot.stackCount -= amount;
                }
                else
                {
                    itemList.Remove(slot);
                    return;
                }
            }
        }
    }
}
[System.Serializable]
public class SlotItem
{
    public Item item;
    public int stackCount;
    public int maxStackCount;
    public SlotItem(Item item, int amount, int maxStackCount)
    {
        this.item = item;
        this.stackCount = amount;
        this.maxStackCount = maxStackCount;
    }
}

