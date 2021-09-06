using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string menuScene;
    [SerializeField] private string gameScene;
    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Invoke(nameof(LoadGame), 0.5f); //for tests now
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuScene);
    }



}
