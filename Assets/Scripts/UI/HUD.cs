using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class HUD : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenu;
    private GameState _gameState;

    private void OnEnable()
    {
        _gameState = GameState.Instance;
        _gameState.Pause += OpenPauseMenu;
    }

    private void OpenPauseMenu()
    {
        _pauseMenu.SetActive(true);
    }

}
