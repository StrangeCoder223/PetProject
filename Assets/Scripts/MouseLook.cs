using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensetivity;
    [SerializeField] private Transform character;
    private float _x, _y;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Look()
    {
        _x += Input.GetAxis("Mouse X") * sensetivity;
        _y += Input.GetAxis("Mouse Y") * sensetivity;
        _y = Mathf.Clamp(_y, -90f, 90f);
        transform.rotation = Quaternion.Euler(-_y, _x, 0f);
        RotateCharacter(character.rotation.x,_x);
    }

    private void RotateCharacter(float x, float y)
    {
        character.rotation = Quaternion.Euler(x,y,0f);
    }

    public Transform GetTarget()
    {
        return character;
    }

    void Update()
    {
        Look();
    }
}
