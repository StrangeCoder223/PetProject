using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDieState : State
{
    private string _dieAnimation = "Die";
    private Character _character;

    public override void Init(Unit character)
    {
        _character = character as Character;
        _character.Animator.SetBool(_dieAnimation, true);
    }
    public override void Run()
    {
        
    }
}
