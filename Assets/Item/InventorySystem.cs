using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;
    void Awake(){
        Instance = this;
    }

    public List<SlotItem> itemList = new List<SlotItem>();

    public void Add(Item item, int amount)
    {

    }
    public void Remove(Item item, int amount)
    {

    }
}
[System.Serializable]
public struct SlotItem
{
    [SerializeField] private Item item;
    [SerializeField] private int stackCount;
    [SerializeField] private int maxStackCount;
    public SlotItem(Item item, int amount,int maxStackCount){
        this.item = item;
        this.stackCount = amount;
        this.maxStackCount = maxStackCount;
    }
}

