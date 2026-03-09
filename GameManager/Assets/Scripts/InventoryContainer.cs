using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : MonoBehaviour
{
    public List<InventoryItemSO> startingItems = new();
    public Dictionary<InventoryItemSO, InventoryItemData> containerContents = new Dictionary<InventoryItemSO, InventoryItemData>();
    public InventoryManager playerInventory;
    public event Action<InventoryContainer> onContainerUpdated;

    void Start()
    {
        foreach(InventoryItemSO item in startingItems)
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

        onContainerUpdated?.Invoke(this);
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

        onContainerUpdated?.Invoke(this);
    }
}
