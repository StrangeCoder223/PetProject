using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    private string _dieAnimation = "Die";
    private Animator _animator;

    public DieState(Animator animator)
    {
        _animator = animator;
    }

    public override void Init()
    {
        _animator.SetBool(_dieAnimation, true);
        
    }
    public override void Run()
    {
        
    }
}
