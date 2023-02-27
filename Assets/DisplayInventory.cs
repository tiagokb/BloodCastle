using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DisplayInventory : MonoBehaviour
{

    public InventoryObject inventory;
    public GameObject IconHolderPrefab;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;
    Dictionary<InventorySlots, GameObject> itemsDisplayed = new Dictionary<InventorySlots, GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        CreateDisplay();
        inventory.inventoryChanged += UpdateDisplay;
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {

            CreateSlotInWorld(inventory.Container[i], i);
        }
    }

    public void UpdateDisplay()
    {

        for (int i = 0; i < inventory.Container.Count; i++)
        {

            InventorySlots slot = inventory.Container[i];
            GameObject iconHolder;

            if (itemsDisplayed.TryGetValue(slot, out iconHolder))
            {
                iconHolder.GetComponent<UnityEngine.UI.Image>().overrideSprite = inventory.Container[i].ItemObject.iconSprite;
                iconHolder.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            } 
            else
            {

                CreateSlotInWorld(inventory.Container[i], i);
            }
        }
    }

    private void CreateSlotInWorld(InventorySlots slot, int position)
    {
        var iconHolderPrefab = Instantiate(IconHolderPrefab, Vector3.zero, Quaternion.identity, transform);
        iconHolderPrefab.GetComponent<Transform>().localPosition = GetPosition(position);
        iconHolderPrefab.GetComponent<UnityEngine.UI.Image>().overrideSprite = slot.ItemObject.iconSprite;
        iconHolderPrefab.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
        itemsDisplayed.Add(slot, iconHolderPrefab);
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEM * (i / NUMBER_OF_COLUMN)), 0f);   
    }
}
