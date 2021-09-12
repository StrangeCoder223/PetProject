using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeapon : Weapon
{

    private void OnEnable()
    {
        WeaponType = WeaponType.Main;
    }

    public override void Aim(bool isAiming)
    {
        throw new System.NotImplementedException();
    }

    public override void Attack(bool isAttacking)
    {
        
    }

    protected override void Shake(bool isMoving)
    {
        throw new System.NotImplementedException();
    }
}
