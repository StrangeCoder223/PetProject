using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour
{
    
    #region Delegates&Events

    public delegate void OnEventHandler();
    public delegate void OnPressedHandler(bool isPressed);

    public event OnEventHandler ScrolledUp;
    public event OnEventHandler ScrolledDown;
    public event OnEventHandler Attacked;
    public event OnEventHandler Aimed;
    public event OnEventHandler Moved;

    public event OnEventHandler Dropped;

    public event OnPressedHandler Moving;


    #endregion

    public static InputChecker instance;

    private float _scrollRatio;
    
    private KeyBinder _binder;

    private void OnEnable()
    {
        _binder = KeyBinder.instance;
        if (instance == null)
        {
            instance = this;
        }
    }

    private void CheckKeyboard()
    {
        CheckDrop();
        CheckMove();
    }

    private void CheckMove()
    {
        if (Input.GetKey(_binder.GetBinds(KeyType.Forward)))
        {
            Moving?.Invoke(true);
        }
        else if (Input.GetKeyUp(_binder.GetBinds(KeyType.Forward)))
        {
            Moving?.Invoke(false);
        }
        if (Input.GetKey(_binder.GetBinds(KeyType.Backward)))
        {
            Moving?.Invoke(true);
        }
        else if (Input.GetKeyUp(_binder.GetBinds(KeyType.Backward)))
        {
            Moving?.Invoke(false);
        }
        if (Input.GetKey(_binder.GetBinds(KeyType.Right)))
        {
            Moving?.Invoke(true);
        }
        else if (Input.GetKeyUp(_binder.GetBinds(KeyType.Right)))
        {
            Moving?.Invoke(false);
        }
        if (Input.GetKey(_binder.GetBinds(KeyType.Left)))
        {
            Moving?.Invoke(true);
        }
        else if (Input.GetKeyUp(_binder.GetBinds(KeyType.Left)))
        {
            Moving?.Invoke(false);
        }
    }

    private void CheckScroll()
    {
        _scrollRatio = Input.GetAxis("Mouse ScrollWheel");
        if (_scrollRatio > 0.5f)
        {
            ScrolledUp?.Invoke();
        }
        else if (_scrollRatio < -0.5f)
        {
            ScrolledDown?.Invoke();
        }
    }

    private void CheckDrop()
    {
        if (Input.GetKeyDown(_binder.GetBinds(KeyType.Drop)))
        {
            Dropped?.Invoke();
        }
    }

    private void CheckMouse()
    {
        if (Input.GetKey(_binder.GetBinds(KeyType.Attack)))
        {
            Attacked?.Invoke();
        }
        if (Input.GetKey(_binder.GetBinds(KeyType.Aim)))
        {
            Aimed?.Invoke();
        }
        CheckScroll();
    }

    private void Update()
    {
        CheckKeyboard();
        CheckMouse();
    }
}
