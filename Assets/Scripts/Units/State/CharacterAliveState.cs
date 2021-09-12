using UnityEngine;

public class CharacterAliveState : State
{
    private Character _character;
    private CharacterMovement _movement;
    private InputChecker _input;
    private Inventory _inventory;
    public override void Init(Unit unit)
    {
        _character = unit as Character;
        _movement = new CharacterMovement(_character);
        _input = InputChecker.Instance;
        _inventory = _character.Inventory;
        SubscribeOnEvents();
    }

    private void SubscribeOnEvents()
    {
        _input.ScrolledUp += _inventory.NextSlot;
        _input.ScrolledDown += _inventory.PreviousSlot;
        _input.Dropped += _inventory.DropWeapon;
    }

    private void DescribeFromEvents()
    {
        _input.ScrolledUp -= _inventory.NextSlot;
        _input.ScrolledDown -= _inventory.PreviousSlot;
        _input.Dropped -= _inventory.DropWeapon;
    }

    public override void Run()
    {
        _inventory.CurrentSlot.Item.Attack(_input.IsAttack);
        _inventory.CurrentSlot.Item.Aim(_input.IsAim);
        _movement.CheckMovement();
    }

    public override void Exit()
    {
        DescribeFromEvents();
    }


}
