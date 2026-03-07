using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<InventoryItemSO, InventoryItemData> playerInventory = new Dictionary<InventoryItemSO, InventoryItemData>();
    public InventoryItemSO[] tmp;

    private void Start()
    {
        foreach (InventoryItemSO item in tmp)
        {
            AddItem(item);
        }
    }

    public void AddItem(InventoryItemSO itemToAdd_)
    {
        if(!playerInventory.TryAdd(itemToAdd_, itemToAdd_.CreateRuntimeData()))
        {
            playerInventory[itemToAdd_].quantity++;
        }
    }

    public void RemoveItem(InventoryItemSO itemToRemove_)
    {
        if(playerInventory[itemToRemove_].quantity > 1)
        {
            playerInventory[itemToRemove_].quantity--;
        }
        else
        {
            playerInventory.Remove(itemToRemove_);
        }
    }
}

[Serializable]
public class InventoryItemData
{
    public InventoryItemSO config;
    public int quantity;
    public string itemName;
    public string flavourText;
    public Sprite icon;
}

[Serializable]
public class WeaponItemData : InventoryItemData
{
    public int weaponStrength;
    public int weaponDurability;
    public WeaponType weaponType;

    public WeaponItemData(WeaponItemSO config)
    {
        this.config = config;

        this.flavourText = config.flavourText;
        this.itemName = config.itemName;
        this.icon = config.icon;

        this.weaponDurability = config.weaponDurability;
        this.weaponStrength = config.weaponStrength;
        quantity = 1;
    }
}

[Serializable]
public class ArmorItemData : InventoryItemData
{
    public int armorRating;
    public int armorDuribility;
    public ArmorSlot armorSlot;

    public ArmorItemData(ArmourItemSO config)
    {
        
        this.config = config;

        this.flavourText = config.flavourText;
        this.itemName = config.itemName;
        this.icon = config.icon;
        
        this.armorRating = config.armourRating;
        this.armorDuribility = config.armourDuribility;
        this.armorSlot = config.armorSlot;
        quantity = 1;
    }
}