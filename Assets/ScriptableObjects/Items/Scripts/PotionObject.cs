using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion item Object", menuName = "Inventory System/Items/Potion Item")]
public class PotionObject : ItemObject
{

    public int restoreHealthValue;
    private void Awake()
    {
        type = ItemType.Potion;
    }
}
