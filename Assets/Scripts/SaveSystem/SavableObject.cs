using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SavableObject : MonoBehaviour
{
    #region ForSave
    
    public Vector3 Position { get => _position; set => _position = value; }
    public Quaternion Rotation { get => _rotation; set => _rotation = value; }
    public Vector3 Scale { get => _scale; set => _scale = value; }

    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _scale;
    [SerializeField] private Quaternion _rotation;
    #endregion

    public void Initialize()
    {
        transform.position = Position;
        transform.rotation = Rotation;
        transform.localScale = Scale;
    }

    public abstract string GetSaveFormat();
}
