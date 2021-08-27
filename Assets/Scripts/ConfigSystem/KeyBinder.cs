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
    Escape
}

public class KeyBinder : MonoBehaviour
{
    public static KeyBinder instance;

    private Dictionary<KeyType, KeyCode> keys = new Dictionary<KeyType, KeyCode>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
    }

    public KeyCode GetBinds(KeyType bind)
    {
        return keys[bind];
    }
}
