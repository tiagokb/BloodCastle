using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOpenCloseInventory : MonoBehaviour
{

    public KeyCode KeyToggle;
    public GameObject InventoryScreen;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyToggle))
        {
            if (InventoryScreen.activeSelf)
            {
                InventoryScreen.SetActive(false);
            } 
            else
            {
                InventoryScreen.SetActive(true);
            }
        }
    }
}
