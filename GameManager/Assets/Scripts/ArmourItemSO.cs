using UnityEngine;

[CreateAssetMenu(fileName = "ArmourItemSO", menuName = "Inventory System/ArmourItemSO")]
public class ArmourItemSO : InventoryItemSO
{
    public int armourRating;
    public int armourDuribility;
    public ArmorSlot armorSlot;

    public override InventoryItemData CreateRuntimeData()
    {
        return new ArmorItemData(this);
    }
}

public enum ArmorSlot
{
    HEAD,
    CHEST,
    LEGS,
    BOOTS,
    WEAPON
}
