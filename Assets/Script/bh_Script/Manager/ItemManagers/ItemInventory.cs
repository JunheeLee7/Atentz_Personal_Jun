using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    int[] itemAmountArray;
    public int[] ItemAmountArray
    {
        get => itemAmountArray;
        set { itemAmountArray = value; }
    }

    ItemType[] itemTypeArray;
    public ItemType[] ItemTypeArray 
    {
        get => itemTypeArray;
        set { itemTypeArray = value; }
    }

    public const int emptySpace = -1;
    public int emptySpaceStartIndex = 0;
}
