using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    public Dictionary<ArmorSlot, InventoryItemData> equipmentSlots;
    public static EquipmentManager instance;
    public event Action<Dictionary<ArmorSlot, InventoryItemData>> onEquip;

    private void Awake()
    {
        instance = this;
        InitializeEquipment();
    }

    public void InitializeEquipment()
    {
        equipmentSlots = new Dictionary<ArmorSlot, InventoryItemData>();
        equipmentSlots.Add(ArmorSlot.HEAD, null);
        equipmentSlots.Add(ArmorSlot.CHEST, null);
        equipmentSlots.Add(ArmorSlot.GLOVES, null);
        equipmentSlots.Add(ArmorSlot.BOOTS, null);
        equipmentSlots.Add(ArmorSlot.WEAPON, null);
    }

    public void EquipItem(InventoryItemData itemToEquip)
    {
        if (itemToEquip is ArmorItemData armor)
        {
            equipmentSlots[armor.armorSlot] = itemToEquip;

            Debug.Log(equipmentSlots[armor.armorSlot].itemName + " is equipped");
        }
        else if(itemToEquip is WeaponItemData weapon)
        {
            equipmentSlots[ArmorSlot.WEAPON] = weapon;

            Debug.Log(equipmentSlots[ArmorSlot.WEAPON].itemName + " is equipped");
        }
        onEquip?.Invoke(equipmentSlots);
    }
}

public class EquipmentSlot
{
    public ArmorSlot armorSlot;
    public InventoryItemData equippedItem;
}