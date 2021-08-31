using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SceneObjectKeeper : MonoBehaviour
{
    public static SceneObjectKeeper Instance;
    [SerializeField] private SavableObjectStatic[] _staticObjects;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _staticObjects = FindStaticObjects();

    }

    private SavableObjectStatic[] FindStaticObjects()
    {
        return FindObjectsOfType<SavableObjectStatic>();
    }

    public SavableObjectStatic[] GetStaticObjects()
    {
        return _staticObjects;
    }
    
    public SavableObjectDynamic[] FindDynamicObjects()
    {
        return FindObjectsOfType<SavableObjectDynamic>();
    }

    public SavableObject[] FindAllObjects()
    {
        return FindObjectsOfType<SavableObject>();
    }
}
