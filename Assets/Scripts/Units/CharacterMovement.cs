using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement
{
    private Character _movementUnit;
    private Characteristics _data;
    private KeyBinder _binder;

    public CharacterMovement(Character movementUnit)
    {
        _movementUnit = movementUnit;
        _data = _movementUnit.GetData();
        _binder = KeyBinder.Instance;
    }

    public void CheckMovement()
    {
        if (Input.GetKey(_binder.GetBinds(KeyType.Forward)))
        {
            Move(_movementUnit.transform.forward);
        }
        if (Input.GetKey(_binder.GetBinds(KeyType.Backward)))
        {
            Move(-_movementUnit.transform.forward);
        }
        if (Input.GetKey(_binder.GetBinds(KeyType.Left)))
        {
            Move(-_movementUnit.transform.right);
        }
        if (Input.GetKey(_binder.GetBinds(KeyType.Right)))
        {
            Move(_movementUnit.transform.right);
        }
        if (OnGround() && Input.GetKeyDown(_binder.GetBinds(KeyType.Jump)))
        {
            Jump();
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 velocity = _movementUnit.Physic.velocity;
        if (velocity.magnitude >= _data.MaxSpeed)
        {
            velocity = Vector3.ClampMagnitude(velocity, _data.MaxSpeed);
        }
        velocity += direction * _data.Speed * _data.AccelerationFactor;
        _movementUnit.Physic.velocity = velocity;
        
    }

    private void Jump()
    {
        _movementUnit.Physic.AddForce(Vector3.up * _data.JumpForce, ForceMode.Acceleration);
    }

    private bool OnGround()
    {
        bool isGrounded = Physics.Raycast(_movementUnit.transform.position, -_movementUnit.transform.up, _data.GroundDistance);
        return isGrounded;
    }

    
}
