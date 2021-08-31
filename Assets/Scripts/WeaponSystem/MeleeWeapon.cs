using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    private void Awake()
    {
        _input = InputChecker.instance;
    }

    private void Start()
    {
        _input.Moved += Shake;
        _input.Attacked += Attack;
        _input.Aimed += Aim;
    }

    private void OnDisable()
    {
        _input.Moved -= Shake;
        _input.Attacked -= Attack;
        _input.Aimed -= Aim;
    }

    public override void Aim()
    {
        PlayAnimTrigger(HardAttackName);
    }

    public override void Attack()
    {
        PlayAnimTrigger(AttackName);
    }

    protected override void Shake()
    {
        PlayAnimTrigger(ShakeName);
    }

    private void PlayAnimTrigger(string name)
    {
        _animator.SetTrigger(name);
        _animator.ResetTrigger(name);
    }

}
