using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : MonoBehaviour
{
    public List<InventoryItemSO> StartingItems = new();
    public Dictionary<InventoryItemSO, InventoryItemData> containerContents = new Dictionary<InventoryItemSO, InventoryItemData>();
    public InventoryManager playerInventory;

    void Start()
    {
        foreach(InventoryItemSO item in StartingItems)
        {
            if(!containerContents.TryAdd(item, item.CreateRuntimeData()))
            {
                containerContents[item].quantity++;
            }
        }
    }

    public void AddItemToContainer(InventoryItemSO itemToAdd_)
    {
        //Remove item from player
        playerInventory.RemoveItem(itemToAdd_);

        //Add item to container
        if(!containerContents.TryAdd(itemToAdd_, itemToAdd_.CreateRuntimeData()))
        {
            containerContents[itemToAdd_].quantity++;
        }
    }

    public void AddItemToPlayerInventory(InventoryItemSO itemToAdd_)
    {
        //Remove item from container
        if(containerContents[itemToAdd_].quantity > 1)
        {
            containerContents[itemToAdd_].quantity--;
        }
        else
        {
            containerContents.Remove(itemToAdd_);
        }

        //Add item to player
        playerInventory.AddItem(itemToAdd_);
    }
}
