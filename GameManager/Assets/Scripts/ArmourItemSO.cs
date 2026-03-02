using UnityEngine;

[CreateAssetMenu(fileName = "ArmourItemSO", menuName = "Inventory System/ArmourItemSO")]
public class ArmourItemSO : InventoryItemSO
{
    public int armourRating;
    public int armourDuribility;
    public ArmourSlot armourSlot;

    public override InventoryItemData CreateRuntimeData()
    {
        return new ArmourItemData(this);
    }
}

public enum ArmourSlot
{
    HEAD,
    CHEST,
    LEGS,
    BOOTS
}
