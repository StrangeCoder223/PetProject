using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensetivity;
    private float _x, _y;

    private void Look()
    {
        _x += Input.GetAxis("Mouse X") * sensetivity;
        _y += Input.GetAxis("Mouse Y") * sensetivity;
        _x = Mathf.Clamp(_x, -90f, 90f);
        transform.rotation = Quaternion.Euler(-_y, _x, 0f);
    }

    void Update()
    {
        Look();
    }
}
