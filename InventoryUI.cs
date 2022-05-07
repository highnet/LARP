using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public List<InventorySlot> inventorySlots;
    public Sprite[] sprites;
    public Inventory inventory;
    public bool objectMetaDataNeedsUpdating;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

    }

    public void UpdateInventoryObjects()
    {
        for(int i = 0; i < inventory.objects.Count; i++)
        {
            inventorySlots[i].@object = inventory.objects[i];
            inventorySlots[i].amount = inventory.amounts[i];

            objectMetaDataNeedsUpdating = true;
        }
    }

    public void UpdateInventoryTexts()
    {
        for (int i = 0; i < inventory.objects.Count; i++)
        {
            inventorySlots[i].nameText.text = inventorySlots[i].@object.name;
            inventorySlots[i].amountText.text = inventorySlots[i].amount.ToString();
        }
    }

    private void Update()
    {

        if (objectMetaDataNeedsUpdating)
        {
            UpdateInventoryTexts();
            objectMetaDataNeedsUpdating = false;
        }
    }
}
