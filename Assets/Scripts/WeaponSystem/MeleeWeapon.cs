using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MeleeWeapon : Weapon
{
    private Animator _animator;
    private InputChecker _input;

    private const string AttackName = "Attack";
    private const string HardAttackName = "HardAttack";
    private const string ShakeName = "Shake";

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _input = InputChecker.Instance;
        _input.Moving += Shake;
        _input.Attacked += Attack;
        _input.Aimed += Aim;
    }

    private void OnDisable()
    {
        _input.Moving -= Shake;
        _input.Attacked -= Attack;
        _input.Aimed -= Aim;
    }

    public override void Aim(bool isAimed)
    {
        _animator.SetBool(HardAttackName, isAimed);
    }

    public override void Attack(bool isAttacking)
    {
        _animator.SetBool(AttackName, isAttacking);
    }

    protected override void Shake(bool isMoving)
    {
        _animator.SetBool(ShakeName, isMoving);
    }

    

}
