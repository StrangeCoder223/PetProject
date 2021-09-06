using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = value;
            _currentState.Init(this);
            StateChanged?.Invoke(value);
        }
    }

    [field: SerializeField]
    public MouseLook Head { get; private set; }

    [field: SerializeField]
    public Inventory Inventory { get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody Physic { get; private set; }

    private State _currentState;

    private void OnEnable()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        Physic = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        CurrentState = new CharacterAliveState();
    }

    public override void TakeDamage(float damage)
    {
        Damaged?.Invoke(damage);
        if (_unitData.Health <= damage)
        {
            CurrentState = new CharacterDieState();
        }
    }

    private void Update()
    {
        CurrentState.Run();
    }

    
}
