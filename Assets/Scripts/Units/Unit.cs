using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    [SerializeField]
    protected Characteristics _unitData;

    protected abstract State CurrentState { get; set; }

    protected abstract void Initialize();

    public virtual Characteristics GetData()
    {
        return _unitData;
    }

    public virtual void TakeDamage(float damage) { }
}
