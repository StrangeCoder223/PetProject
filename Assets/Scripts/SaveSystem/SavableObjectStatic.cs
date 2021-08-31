using System;
using UnityEngine;


public class SavableObjectStatic : SavableObject
{
    [SerializeField] private int _gameObjectId;

    private void Awake()
    {
        _gameObjectId = GetInstanceID();
    }

    public int GetId()
    {
        return _gameObjectId;
    }
    
    public override string GetSaveFormat()
    {
        Position = transform.position;
        Rotation = transform.rotation;
        Scale = transform.localScale;
        return "#static " + JsonUtility.ToJson(this);
    }
}