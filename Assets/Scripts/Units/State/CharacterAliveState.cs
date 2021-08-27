using UnityEngine;

public class CharacterAliveState : State
{
    private Character _character;
    private CharacterMovement _movement;
    

    public override void Init(Unit unit)
    {
        _character = unit as Character;
        _movement = new CharacterMovement(_character);
        Debug.Log("Initialized!");
    }

    public override void Run()
    {
        _movement.CheckMovement();
    }

    
}
