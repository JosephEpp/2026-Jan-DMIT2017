using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    public EquipmentButton[] equipmentUISlots = new EquipmentButton[5];
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
        equipmentSlots.Add(ArmorSlot.GLOVES, null);
        equipmentSlots.Add(ArmorSlot.BOOTS, null);
        equipmentSlots.Add(ArmorSlot.WEAPON, null);
    }

    public void EquipItem(InventoryItemData itemToEquip)
    {
        if (itemToEquip is ArmorItemData armor)
        {
            equipmentSlots[armor.armorSlot] = itemToEquip;
            UpdateEquipmentUI(itemToEquip);

            Debug.Log(equipmentSlots[armor.armorSlot].itemName + " is equipped");
        }
        else if(itemToEquip is WeaponItemData weapon)
        {
            equipmentSlots[ArmorSlot.WEAPON] = weapon;
            UpdateEquipmentUI(itemToEquip);

            Debug.Log(equipmentSlots[ArmorSlot.WEAPON].itemName + " is equipped");
        }
    }

    public void UpdateEquipmentUI(InventoryItemData itemToEquip)
    {
        if (itemToEquip is ArmorItemData armor)
        {
            switch(armor.armorSlot)
            {
                case ArmorSlot.HEAD:
                    {
                        equipmentUISlots[0].itemName.text = armor.itemName;
                        equipmentUISlots[0].icon.sprite = armor.icon;
                        break;
                    }
                case ArmorSlot.CHEST:
                    {
                        equipmentUISlots[1].itemName.text = armor.itemName;
                        equipmentUISlots[1].icon.sprite = armor.icon;
                        break;
                    }
                case ArmorSlot.GLOVES:
                    {
                        equipmentUISlots[2].itemName.text = armor.itemName;
                        equipmentUISlots[2].icon.sprite = armor.icon;
                        break;
                    }
                case ArmorSlot.BOOTS:
                    {
                        equipmentUISlots[3].itemName.text = armor.itemName;
                        equipmentUISlots[3].icon.sprite = armor.icon;
                        break;
                    }
            }
        }
        else if(itemToEquip is WeaponItemData weapon)
        {
            equipmentUISlots[4].itemName.text = weapon.itemName;
            equipmentUISlots[4].icon.sprite = weapon.icon;
        }
    }
}

public class EquipmentSlot
{
    public ArmorSlot armorSlot;
    public InventoryItemData equippedItem;
}