using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private Player _player;
    [Inject] private MenuUI _menuUI;
    [Inject] private GameUI _gameUI;
    [Inject] private Spawner _spawner;

    // current score ?

    public void StartGame()
    {
        _spawner.StartSpawn();
        _player.StartFly();
        // in method
        _menuUI.gameObject.SetActive(false);
        _gameUI.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        // stop barriers
        // stop backgrounds
        // fix bird position
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
