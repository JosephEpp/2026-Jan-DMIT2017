using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public InventoryManager targetInventory;
    public GameObject buttonPrefab;
    public Transform contentParent;

    private Dictionary<InventoryItemSO, InventoryButton> activeButtons = new Dictionary<InventoryItemSO, InventoryButton>();

    [ContextMenu("Init UI")]
    public void InitUI()
    {
        activeButtons.Clear();

        Dictionary<InventoryItemSO, InventoryItemData> inventoryRef = targetInventory.playerInventory;

        foreach (var item in inventoryRef)
        {
            GameObject tmp = Instantiate(buttonPrefab, contentParent);
            InventoryButton button = tmp.GetComponent<InventoryButton>();
            button.InitializeButton(item.Value);

            activeButtons.Add(item.Key, button);
        }
    }

    public void UpdateUI()
    {
        Dictionary<InventoryItemSO, InventoryItemData> inventoryRef = targetInventory.playerInventory;

        // Remove items that no longer exist
        List<InventoryItemSO> itemsToRemove = new List<InventoryItemSO>();

        foreach (var item in activeButtons)
        {
            if (!inventoryRef.ContainsKey(item.Key))
            {
                Destroy(item.Value.gameObject);
                itemsToRemove.Add(item.Key);
            }
        }

        foreach (var item in itemsToRemove)
        {
            activeButtons.Remove(item);
        }

        // Add new items & update existing ones
        foreach (var item in inventoryRef)
        {
            if (activeButtons.ContainsKey(item.Key))
            {
                // Update existing UI
                activeButtons[item.Key].InitializeButton(item.Value);
            }
            else
            {
                // Add new UI element
                GameObject tmp = Instantiate(buttonPrefab, contentParent);
                InventoryButton button = tmp.GetComponent<InventoryButton>();
                button.InitializeButton(item.Value);

                activeButtons.Add(item.Key, button);
            }
        }
    }
}