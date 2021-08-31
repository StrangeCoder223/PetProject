using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableObjectDynamic : SavableObject
{
    [SerializeField] private ObjectType _objectType;

    public override string GetSaveFormat()
    {
        Position = transform.position;
        Rotation = transform.rotation;
        Scale = transform.localScale;
        return _objectType + " " + JsonUtility.ToJson(this);
    }
}
