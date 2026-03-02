using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<InventoryItemSO, InventoryItemData> playerInventory = new Dictionary<InventoryItemSO, InventoryItemData>();
    public WeaponItemSO itemToAdd;

    private void Start()
    {
        AddItem(itemToAdd);
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
            playerInventory[itemToAdd].quantity--;
        }
    }
}

public class InventoryItemData
{
    public InventoryItemSO config;
    public int quantity;
}

[Serializable]
public class WeaponItemData : InventoryItemData
{
    public int weaponStrength;
    public int weaponDuribility;
    public WeaponType weaponType;

    public WeaponItemData(WeaponItemSO config)
    {
        this.config = config;

        this.weaponStrength = config.weaponStrength;
        this.weaponDuribility = config.weaponDuribility;
        this.weaponType = config.weaponType;
        quantity = 1;
    }
}

[Serializable]
public class ArmourItemData : InventoryItemData
{
    public int armourRating;
    public int armourDuribility;
    public ArmourSlot armourSlot;

    public ArmourItemData(ArmourItemSO config)
    {
        this.config = config;
        this.armourRating = config.armourRating;
        this.armourDuribility = config.armourDuribility;
        this.armourSlot = config.armourSlot;
        quantity = 1;
    }
}