using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Dictionary<ArmorSlot, InventoryItemData> equipmentSlots;
    public static EquipmentManager instance;

    private void Start()
    {
        instance = this;
        InitializeEquipment();
    }
    public void InitializeEquipment()
    {
        equipmentSlots = new Dictionary<ArmorSlot, InventoryItemData>();
        equipmentSlots.Add(ArmorSlot.HEAD, null);
        equipmentSlots.Add(ArmorSlot.CHEST, null);
        equipmentSlots.Add(ArmorSlot.LEGS, null);
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
    }
}

public class EquipmentSlot
{
    public ArmorSlot armorSlot;
    public InventoryItemData equippedItem;
}