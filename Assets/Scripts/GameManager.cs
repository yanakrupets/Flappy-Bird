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
    [Inject] private GameOverUI _gameOverUI;
    [Inject] private Spawner _spawner;

    private void Awake()
    {
        EventManager.AddListener<GameOverEvent>(GameOver);
    }

    public void StartGame()
    {
        _spawner.StartSpawn();
        _player.Fly();

        _menuUI.gameObject.SetActive(false);
        _gameUI.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        var stopMovementEvent = Events.StopMovementEvent;
        EventManager.Broadcast(stopMovementEvent);
    }

    public void ContinueGame()
    {
        var continueMovementEvent = Events.ContinueMovementEvent;
        EventManager.Broadcast(continueMovementEvent);
    }

    public void GameOver(GameOverEvent evt)
    {
        PauseGame();

        _gameUI.gameObject.SetActive(false);
        _gameOverUI.gameObject.SetActive(true);
        _gameOverUI.ShowResult(evt.currentScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
