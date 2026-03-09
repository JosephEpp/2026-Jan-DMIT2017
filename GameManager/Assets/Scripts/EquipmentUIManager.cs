using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIManager : MonoBehaviour
{
    public EquipmentUISlot[] equipmentUISlots = new EquipmentUISlot[5];

    private void Start()
    {
        EquipmentManager.instance.onEquip += UpdateUI;
    }

    public void UpdateUI(Dictionary<ArmorSlot, InventoryItemData> equipment)
    {
        foreach(ArmorSlot a in equipment.Keys)
        {
            if (equipment[a] is ArmorItemData armor)
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
            else if(equipment[a] is WeaponItemData weapon)
            {
                equipmentUISlots[4].itemName.text = weapon.itemName;
                equipmentUISlots[4].icon.sprite = weapon.icon;
            }
        }
    }
}

[Serializable]
public class EquipmentUISlot
{
    [SerializeField] private ArmorSlot itemSlot;
    public TMP_Text itemName;
    public Image icon;
}
