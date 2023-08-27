using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIInventory : MonoBehaviour
{
    public static UIInventory Instance;
    public List<GameObject> UISlot;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform contentTransform;
    [SerializeField] private GameObject InventoryPrefab;
    public GameObject CurrentSelectSlot;

    private void Awake()
    {
        Instance = this;
    }

    // private GameObject CreateUISlot(SlotItem slotItem)
    // {
    //     GameObject slot = Instantiate(slotPrefab, contentTransform);
    //     slot.transform.GetComponentInChildren<Image>().sprite = slotItem.item._icon;
    //     return slot;
    // }
    // public void RefreshUIInventory()
    // {
    //     List<SlotItem> _slotItem = InventorySystem.Instance.itemList;

    //     foreach (SlotItem slotItem in _slotItem)
    //     {
    //         GameObject slot = CreateUISlot();
    //         UISlot.Add(slot);
    //     }
    // }
}
