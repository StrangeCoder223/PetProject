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
        _input.ScrolledUp += _inventory.NextWeapon;
        _input.ScrolledDown += _inventory.PreviousWeapon;
        _input.Dropped += _inventory.DropWeapon;
        _input.Attacked += _inventory.CurrentWeapon.Attack;
        _input.Aimed += _inventory.CurrentWeapon.Aim;
    }

    private void DescribeFromEvents()
    {
        _input.Attacked -= _inventory.CurrentWeapon.Attack;
        _input.Aimed -= _inventory.CurrentWeapon.Aim;
        _input.ScrolledUp -= _inventory.NextWeapon;
        _input.ScrolledDown -= _inventory.PreviousWeapon;
        _input.Dropped -= _inventory.DropWeapon;
    }

    public override void Run()
    {
        _movement.CheckMovement();
    }

    public override void Exit()
    {
        DescribeFromEvents();
    }


}
