using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioMaster))]
[RequireComponent(typeof(AudioSource))]
public class AdditionalWeapon : Weapon
{
    private AudioSource _audioSource;
    private AudioMaster _master;

    private void OnEnable()
    {
        WeaponType = WeaponType.Additional;
        _audioSource = GetComponent<AudioSource>();
        _master = GetComponent<AudioMaster>();
    }

    public override void Aim(bool isAiming)
    {
        //_master.PlaySound(_audioSource, ClipType.Aim);
        Debug.Log("Aimed");
    }

    public override void Attack(bool isAttacking)
    {
        //_master.PlaySound(_audioSource, ClipType.Shoot);
        Debug.Log("Attacked");
    }

    protected override void Shake(bool isMoving)
    {
        
    }
}
