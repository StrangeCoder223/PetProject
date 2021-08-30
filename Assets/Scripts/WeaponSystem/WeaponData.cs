using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : ScriptableObject
{
    [field: SerializeField]
    public float AttackDelay { get; private set; }

    [field: SerializeField]
    public int CurrentAmmo { get; private set; }

    [field: SerializeField]
    public int MagazineAmmo { get; private set; }


}
