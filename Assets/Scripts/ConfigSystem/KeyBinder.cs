using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum KeyType
{
    Forward,
    Backward,
    Left,
    Right,
    Escape,
    Jump,
    Drop,
    Attack,
    Aim
}

public class KeyBinder : MonoBehaviour
{
    public static KeyBinder Instance { get; private set; }

    private Dictionary<KeyType, KeyCode> keys = new Dictionary<KeyType, KeyCode>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        BindDefault();
    }

    public void BindKey(Text keyForBind, KeyType keyType)
    {
        StartCoroutine(WaitInput(keyForBind,keyType));
    }
    public KeyCode GetBinds(KeyType bind)
    {
        return keys[bind];
    }

    private IEnumerator WaitInput(Text keyForBind, KeyType keyType)
    {
        yield return new WaitUntil(() => Input.anyKeyDown);

        KeyCode newKey = KeyCode.None;

        foreach (KeyCode KCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(KCode))
            {
                newKey = KCode;
                break;
            }
        } 
        keys[keyType] = newKey;
        keyForBind.text = newKey.ToString();
    }

    private void BindDefault()
    {
        keys.Add(KeyType.Forward, KeyCode.W);
        keys.Add(KeyType.Backward, KeyCode.S);
        keys.Add(KeyType.Left, KeyCode.A);
        keys.Add(KeyType.Right, KeyCode.D);
        keys.Add(KeyType.Escape, KeyCode.Escape);
        keys.Add(KeyType.Jump, KeyCode.Space);
        keys.Add(KeyType.Drop, KeyCode.G);
        keys.Add(KeyType.Attack, KeyCode.Mouse0);
        keys.Add(KeyType.Aim, KeyCode.Mouse1);
    }
}
