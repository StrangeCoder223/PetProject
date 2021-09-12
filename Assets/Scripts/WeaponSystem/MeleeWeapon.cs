using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MeleeWeapon : Weapon
{
    [SerializeField]
    private float weaponRange;

    private Animator _animator;

    private const string AttackName = "Attack";
    private const string HardAttackName = "HardAttack";
    private const string ShakeName = "Shake";

    private float _impactLength = 0.3f;
    private bool _readyForImpact = true;

    [SerializeField] private SerializableDictionary<HitType, float> damageList = new SerializableDictionary<HitType, float>();

    private void OnEnable()
    {
        WeaponType = WeaponType.Melee;
        _animator = GetComponent<Animator>();
    }

    public override void Aim(bool isAimed)
    {
        _animator.SetBool(HardAttackName, isAimed);
        
    }

    public override void Attack(bool isAttacking)
    {
        _animator.SetBool(AttackName, isAttacking);
        if (isAttacking & _readyForImpact)
        {
            _readyForImpact = false;
            StartCoroutine(GiveImpact());
        }
    }

    protected override void Shake(bool isMoving)
    {
        _animator.SetBool(ShakeName, isMoving);
    }

    private IEnumerator GiveImpact()
    {
        yield return new WaitForSeconds(AttackDelay);

        Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0f));

        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out RaycastHit hit, weaponRange))
        {
            if (hit.transform.gameObject.TryGetComponent(out HitBox hitBox))
            {
                hitBox.ApplyHit(damageList[hitBox.HitType]);
            }
            
        }

        yield return new WaitForSeconds(_impactLength);

        _readyForImpact = true;
    }

    

}
