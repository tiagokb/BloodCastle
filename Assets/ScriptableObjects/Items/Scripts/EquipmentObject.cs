using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New equip item Object", menuName = "Inventory System/Items/Equipment Item")]
public class EquipmentObject : ItemObject
{

    public Sprite iconSprite;

    public float StrengthBonus;
    public float DefenceBonus;

    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
