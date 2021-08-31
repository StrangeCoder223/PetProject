using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [field: SerializeField]
    public float AttackDelay { get; private set; }

    [field: SerializeField]
    public int CurrentAmmo { get; private set; }

    [field: SerializeField]
    public int MagazineAmmo { get; private set; }

    [field: SerializeField]
    public GameObject DropPrefab { get; private set; }

    public abstract void Attack();
    public abstract void Aim();
    protected abstract void Shake();
    
}
