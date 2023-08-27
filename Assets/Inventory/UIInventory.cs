using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            RefreshUIInventory();
        }
    }
    private GameObject CreateUISlot(SlotItem slotItem)
    {
        GameObject slot = Instantiate(slotPrefab, contentTransform);

        slot.transform.GetChild(0).GetComponent<Image>().sprite = slotItem.item._icon;
        slot.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = slotItem.stackCount.ToString();
        return slot;
    }
    public void RefreshUIInventory()
    {
        List<SlotItem> _slotItem = InventorySystem.Instance.itemList;

        foreach (Transform child in contentTransform)
        {
            Destroy(child.gameObject);
        }
        UISlot.Clear();
        foreach (SlotItem slotItem in _slotItem)
        {
            GameObject slot = CreateUISlot(slotItem);
            UISlot.Add(slot);
        }
    }
}
