using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    #region Delegates&Events

    public delegate void OnGameState();
    public event OnGameState Lose;
    public event OnGameState Win;
    public event OnGameState AtPlay;
    public event OnGameState Pause;

    #endregion

    [SerializeField]
    private Character _character;

    public static GameState Instance { get; private set; }
    

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _character.StateChanged += ReactOnCharacterState;
    }

    private void ReactOnCharacterState(State newState)
    {
        Type type = newState.GetType();

        if (type == typeof(CharacterAliveState))
        {
            AtPlay?.Invoke();
        }

        else if (type == typeof(CharacterDieState))
        {
            Lose?.Invoke();
        }
    }


    

}
