using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Cube,
    Sphere
    
}
[CreateAssetMenu(fileName = "AllObjectsConfig", menuName = "Data/Config/AllObjectsConfig", order = 52)]
public class ObjectsConfig : ScriptableObject
{
    
    public SerializableDictionary<ObjectType, SavableObjectDynamic> AllObjects
    {
        get => _allObjects;
        private set => _allObjects = value;
    }

    [SerializeField] private SerializableDictionary<ObjectType, SavableObjectDynamic> _allObjects;
}
