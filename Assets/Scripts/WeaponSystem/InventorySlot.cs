using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventorySlot: MonoBehaviour
{
    public bool IsEmpty
    {
        get => Item == null;
    }

    [field: SerializeField]
    public Weapon Item { get; set; }

    [field: SerializeField]
    public WeaponType SlotType { get; set; }

    public int Index { get; set; }
}
