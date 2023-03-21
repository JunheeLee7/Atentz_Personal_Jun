using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryWindow : MonoBehaviour
{
    // Start is called before the first frame update

    ItemInventoryWindowRoom[] itemInventoryWindowRooms;
    ItemInventoryWindowExplanRoom explanRoom;
    void Awake()
    {
        itemInventoryWindowRooms = GetComponentsInChildren<ItemInventoryWindowRoom>();
        explanRoom = GetComponentInChildren<ItemInventoryWindowExplanRoom>();
    }

    private void Start()
    {
        RefreshItemInventory();
    }

    public void RefreshItemInventory()
    {
        for (int i = 0; i < ItemManager.Instance.itemInventoryMaxSpace; i++)
        {
            if (ItemManager.Instance.itemInventory.ItemTypeArray[i] != ItemType.Null)
            {
                itemInventoryWindowRooms[i].SetSpace(ItemManager.Instance[ItemManager.Instance.itemInventory.ItemTypeArray[i]].IconSprite, ItemManager.Instance.itemInventory.ItemAmountArray[i]);
            }
            else
            {
                itemInventoryWindowRooms[i].DisableComponent();
            }
        }

    }

    public void SetExplan(int index) 
    {
        for (int i = 0; i < ItemManager.Instance.itemInventory.emptySpaceStartIndex; i++) 
        { 

        }
    }
    // Update is called once per frame
}
