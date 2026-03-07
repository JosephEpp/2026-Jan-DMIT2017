using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContainerButton : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text flavourText;
    public TMP_Text quantityDisplay;
    public Image icon;
    private InventoryItemData inventoryData;
    private InventoryContainer container;

    public void InitializeInventoryButton(InventoryItemData item)
    {
        inventoryData = item;
        itemName.text = item.itemName;
        flavourText.text = item.flavourText;
        quantityDisplay.text = item.quantity.ToString();
        icon.sprite = item.icon;
        GetComponent<Button>().onClick.AddListener(InventoryButtonClick);  // <-- very important
    }

    public void InitializeContainerButton(InventoryItemData item)
    {
        inventoryData = item;
        itemName.text = item.itemName;
        flavourText.text = item.flavourText;
        quantityDisplay.text = item.quantity.ToString();
        icon.sprite = item.icon;
        GetComponent<Button>().onClick.AddListener(ContainerButtonClick);  // <-- very important
    }

    public void InventoryButtonClick()
    {
        container.AddItemToContainer(inventoryData.config);
    }

    public void ContainerButtonClick()
    {
        container.AddItemToPlayerInventory(inventoryData.config);
    }
}