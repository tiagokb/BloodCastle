using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public enum ItemType
{

    Potion,
    Food,
    Equipment,
    Event,
    Default
}

public class ItemObject : ScriptableObject
{

    public GameObject prefab;
    public Sprite iconSprite;
    public ItemType type;

    [TextArea(15, 20)]
    public string description;
}
