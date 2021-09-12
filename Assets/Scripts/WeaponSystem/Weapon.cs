using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Melee,
    Additional,
    Main
}
public abstract class Weapon : MonoBehaviour
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public float AttackDelay { get; private set; }

    [field: SerializeField]
    public int CurrentAmmo { get; private set; }

    [field: SerializeField]
    public int MagazineAmmo { get; private set; }

    [field: SerializeField]
    public GameObject DropPrefab { get; private set; }

    public WeaponType WeaponType { get; set; }

    public abstract void Attack(bool isAttacking);
    public abstract void Aim(bool isAimed);
    protected abstract void Shake(bool isMoving);
}
