using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Object", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{

    public delegate void OnInventoryChanged();
    public event OnInventoryChanged inventoryChanged;

    public List<InventorySlots> Container = new List<InventorySlots>();

    public void AddItem(ItemObject _item, int _amount)
    {

        for (int i = 0; i< Container.Count; i++)
        {
            if (Container[i].ItemObject == _item)
            {

                Container[i].AddAmount(_amount);
                if (inventoryChanged != null)
                    inventoryChanged();
                return;
            }
        }
      
        Container.Add(new InventorySlots(_item, _amount));
        if (inventoryChanged != null)
            inventoryChanged();
    }


    public void Remove(ItemObject _item, int _amount = 1)
    {
        // Remove item from the inventory
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].ItemObject == _item)
            {

                Container[i].RemoveAmount(_amount);
                // Invoke the inventoryChanged event
                if (inventoryChanged != null)
                    inventoryChanged();
                return;
            }
        }
        
    }
}

[System.Serializable]
public class InventorySlots
{

    public ItemObject ItemObject;
    public int amount;

    public InventorySlots (ItemObject _item, int _amount)
    {

        this.ItemObject = _item;    
        this.amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount+= value;
    }

    public void RemoveAmount(int value)
    {
        amount -= value;
    }
}
