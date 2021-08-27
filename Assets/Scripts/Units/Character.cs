using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : Unit
{
    #region Delegates&Events

    public delegate void OnStateChanged(State newState);
    public delegate void OnDamage(float damage);
    public event OnDamage Damaged;
    public event OnStateChanged StateChanged;

    #endregion

    protected override State CurrentState 
    {
        get => _currentState;
        set
        {
            _currentState = value;
            StateChanged?.Invoke(value);
        }
    }

    private Animator _animator;
    private State _currentState;

    private void OnEnable()
    {
        Initialize();
    }
    protected override void Initialize()
    {
        CurrentState = new AliveState();
        _animator = GetComponent<Animator>();
    }

    public override void TakeDamage(float damage)
    {
        Damaged?.Invoke(damage);
        if (_unitData.Health <= damage)
        {
            CurrentState = new DieState(_animator);
        }
    }

    private void Update()
    {
        CurrentState.Run();
    }

    
}
