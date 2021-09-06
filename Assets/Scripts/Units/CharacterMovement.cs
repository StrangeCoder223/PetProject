using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement
{
    private Character _movementUnit;
    private Characteristics _data;
    private KeyBinder _binder;
    private Vector3 _velocity;
    private float _x, _z;
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
            _z = 1;
        }
        else if (Input.GetKeyUp(_binder.GetBinds(KeyType.Forward)))
        {
            _z = 0;
        }
        if (Input.GetKey(_binder.GetBinds(KeyType.Backward)))
        {
            _z = -1;
        }
        else if (Input.GetKeyUp(_binder.GetBinds(KeyType.Backward)))
        {
            _z = 0;
        }
        if (Input.GetKey(_binder.GetBinds(KeyType.Left)))
        {
            _x = -1;
        }
        else if (Input.GetKeyUp(_binder.GetBinds(KeyType.Left)))
        {
            _x = 0;
        }
        if (Input.GetKey(_binder.GetBinds(KeyType.Right)))
        {
            _x = 1;
        }
        else if (Input.GetKeyUp(_binder.GetBinds(KeyType.Right)))
        {
            _x = 0;
        }
        if (OnGround() && Input.GetKeyDown(_binder.GetBinds(KeyType.Jump)))
        {
            Jump();
        }
        else if (!OnGround())
        {
            ApplyGravity();
        }
        Move();
    }

    private void Move()
    {
        Vector3 forward = _movementUnit.Head.GetTarget().forward;
        Vector3 right = _movementUnit.Head.GetTarget().right;
        _velocity = _movementUnit.Physic.velocity;
        _velocity = (right * _x + forward * _z) * _data.Speed;
        _velocity.y = _movementUnit.Physic.velocity.y;
        ApplyVelocity();
    }

    private void ApplyVelocity()
    {
        _movementUnit.Physic.velocity = _velocity;
    }

    private void Jump()
    {
        Vector3 jumpVelocity = _movementUnit.Physic.velocity;
        jumpVelocity.y = Mathf.Sqrt(_data.JumpForce * -2f * _data.GravityForce);
        _movementUnit.Physic.velocity = jumpVelocity;
    }

    private bool OnGround()
    {
        bool isGrounded = Physics.Raycast(_movementUnit.transform.position, -_movementUnit.transform.up, _data.GroundDistance);
        return isGrounded;
    }

    private void ApplyGravity()
    {
        _velocity.y = _data.GravityForce;
    }
}
