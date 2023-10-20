using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Assets/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int quantity;
    public ItemType itemType;
    public enum ItemType{
        bullets,
        points
    }
}
