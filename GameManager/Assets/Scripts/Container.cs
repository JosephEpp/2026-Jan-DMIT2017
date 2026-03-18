using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public InventoryContainer inventoryContainer;
    private ContainerUI containerUI;

    void Awake()
    {
        containerUI = FindFirstObjectByType<ContainerUI>(FindObjectsInactive.Include);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            OpenContainer();
        }
    }

    public void OpenContainer()
    {
        containerUI.UpdateContainerUI(inventoryContainer);
        containerUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
