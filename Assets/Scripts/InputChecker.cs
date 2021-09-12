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
    public event OnEventHandler Moved;
    public event OnEventHandler Dropped;

    public event OnPressedHandler Moving;
    public event OnPressedHandler Attacked;
    public event OnPressedHandler Aimed;


    #endregion

    public static InputChecker Instance { get; private set; }

    public bool IsAttack { get; private set; }

    public bool IsAim { get; private set; }

    [SerializeField] private KeyBinder _binder;

    private float _scrollRatio;
    
    

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void CheckKeyboard()
    {
      //  CheckDrop();
        CheckMove();
    }

    private void CheckMove()
    {
        if (Input.GetKey(_binder.GetBinds(KeyType.Forward)) |
            Input.GetKey(_binder.GetBinds(KeyType.Backward)) |
            Input.GetKey(_binder.GetBinds(KeyType.Left)) |
            Input.GetKey(_binder.GetBinds(KeyType.Right)))
        {
            Moving?.Invoke(true);
        }
        else
        {
            Moving?.Invoke(false);
        }
    }

    private void CheckScroll()
    {
        _scrollRatio = Input.GetAxisRaw("Mouse ScrollWheel");
        if (_scrollRatio > 0)
        {
            ScrolledUp?.Invoke();
        }
        else if (_scrollRatio < 0)
        {
            ScrolledDown?.Invoke();
        }
    }

    private void CheckDrop()
    {
        if (Input.GetKeyDown(_binder.GetBinds(KeyType.Drop)))
        {
            Debug.Log(_binder.GetBinds(KeyType.Drop));
            Dropped?.Invoke();
        }
    }

    private void CheckMouse()
    {
        IsAttack = Input.GetKey(_binder.GetBinds(KeyType.Attack));
        IsAim = Input.GetKey(_binder.GetBinds(KeyType.Aim));
        CheckScroll();
    }

    private void Update()
    {
        CheckKeyboard();
        CheckMouse();
    }
}
