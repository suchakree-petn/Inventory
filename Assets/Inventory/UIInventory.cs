using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIInventory : MonoBehaviour
{
    public static UIInventory Instance;

    [Header("Item List")]
    public List<GameObject> UISlot;
    public Item _currentSelectItem;



    [Header("Description Panel")]
    [SerializeField] private TextMeshProUGUI _descriptionName;
    [SerializeField] private Image _descriptionIcon;
    [SerializeField] private TextMeshProUGUI _descriptionText;

    [Header("UI Transform")]
    [SerializeField] private Transform _inventoryContentTransform;
    [SerializeField] private Transform _descriptionContentTransform;


    [Header("Prefab")]
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private GameObject InventoryPrefab;

    public delegate void InventoryActions(Item item);
    public static InventoryActions OnSlotClick;

    List<SlotItem> _slotItem = new List<SlotItem>();

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _slotItem = InventorySystem.Instance.itemList;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            RefreshUIInventory();
            OnSlotClick?.Invoke(_currentSelectItem);
        }
    }
    private GameObject CreateUISlot(SlotItem slotItem)
    {
        GameObject slot = Instantiate(slotPrefab, _inventoryContentTransform);
        slot.GetComponent<UISlotData>().item = slotItem.item;
        slot.transform.GetChild(0).GetComponent<Image>().sprite = slotItem.item._icon;
        slot.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = slotItem.stackCount.ToString();
        return slot;
    }
    public void RefreshUIInventory()
    {
        // Is list empty?
        if (_slotItem == null)
        {
            return;
        }

        // Clear inventory
        foreach (Transform child in _inventoryContentTransform)
        {
            Destroy(child.gameObject);
        }

        // Clear list
        UISlot.Clear();

        // Create new slot
        foreach (SlotItem slotItem in _slotItem)
        {
            GameObject slot = CreateUISlot(slotItem);
            UISlot.Add(slot);
        }

        // Initial default select slot
        if (_currentSelectItem == null)
        {
            _currentSelectItem = _slotItem[0].item;
        }

        // Enable description
        InitDescriptionUI();

    }

    private void InitDescriptionUI()
    {
        if (_slotItem == null)
        {
            _inventoryContentTransform.gameObject.SetActive(false);
            _descriptionContentTransform.gameObject.SetActive(false);
        }
        else
        {
            _inventoryContentTransform.gameObject.SetActive(true);
            _descriptionContentTransform.gameObject.SetActive(true);
        }
    }
    private void RefreshDescriptionName(Item item)
    {
        if (item != null)
        {
            _descriptionName.text = item._name;
        }
    }
    private void RefreshDescriptionIcon(Item item)
    {
        if (item != null)
        {
            _descriptionIcon.sprite = item._icon;
        }
    }

    private void RefreshDescriptionText(Item item)
    {
        if (item != null)
        {
            _descriptionText.text = item._description;
        }
    }

    private void OnEnable()
    {
        OnSlotClick += RefreshDescriptionName;
        OnSlotClick += RefreshDescriptionIcon;
        OnSlotClick += RefreshDescriptionText;
    }
    private void OnDisable()
    {
        OnSlotClick -= RefreshDescriptionName;
        OnSlotClick -= RefreshDescriptionIcon;
        OnSlotClick -= RefreshDescriptionText;

    }
}
