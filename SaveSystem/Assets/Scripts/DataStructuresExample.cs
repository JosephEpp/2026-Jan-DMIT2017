using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataStructuresExample : MonoBehaviour
{
    int i;
    float o;
    string s;
    char c;

    float maxSpeed;

    public VehicleColor vehicleColor;

    //arrays, lists, dictionaries, hash tables

    public int[] ints;
    public List<InventoryItem> inventory;
    public Dictionary<InventoryItem, int> inventoryDictionary = new Dictionary<InventoryItem, int>(); 

    private void Start()
    {
        InventoryItem shield = new InventoryItem();
        shield.itemName = "Shield";
        shield.weight = 5;
        shield.dmg = 0;
        shield.duribility = 10;

        // foreach(InventoryItem item in inventory)
        // {
        //     if(item.itemName == shield.itemName)
        //     {
        //         //item.count++;
        //         return;
        //     }
        // }

        // inventory.Add(shield);

        AddItem(shield);
        AddItem(shield);
    }

    public void AddItem(InventoryItem item)
    {
        if(inventoryDictionary.ContainsKey(item))
        {
            inventoryDictionary[item]++;
        }
        else
        {
            inventoryDictionary.Add(item, 1);
        }

        Debug.Log(inventoryDictionary[item]);
    }
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int weight;
    public int dmg;
    public int duribility;
    //public int count;
}

public class Profile
{
    int highscore;
    string profileName;
    VehicleColor color;
    GameObject vehicle;
}

public enum VehicleColor
{
    WHITE, BLACK, RED, PURPLE, BLUE
}