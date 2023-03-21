using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField]
    int amountOfHungerRecovery;
    public int AmountOfHungerRecovery { get => amountOfHungerRecovery; }
    [SerializeField]
    string itemName;
    public string ItemName { get => itemName; }
    [SerializeField]
    string explan;
    public string Explan { get => explan; }
    [SerializeField]
    Sprite iconSprite;
    public Sprite IconSprite { get => iconSprite; }
}
