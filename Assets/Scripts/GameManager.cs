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
    [Inject] private BarrierSpawner _barrierSpawner;
    [Inject] private BonusSpawner _bonusSpawner;

    private List<Spawner> spawners;

    private void Start()
    {
        EventManager.Broadcast(Events.StartMovingBackgroundEvent);

        spawners = new List<Spawner>();
        spawners.Add(_barrierSpawner);
        spawners.Add(_bonusSpawner);
    }

    public void StartGame()
    {
        EventManager.Broadcast(Events.StartSpawnEvent);

        _player.StartFly();

        _menuUI.gameObject.SetActive(false);
        _gameUI.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        EventManager.Broadcast(Events.StopMovingBackgroundEvent);
        EventManager.Broadcast(Events.StopSpawnEvent);

        _player.StopFly();
    }

    public void ContinueGame()
    {
        EventManager.Broadcast(Events.StartMovingBackgroundEvent);
        EventManager.Broadcast(Events.StartSpawnEvent);

        _player.StartFly();
    }

    public void GameOver(int currentScore)
    {
        PauseGame();

        _gameUI.gameObject.SetActive(false);
        _gameOverUI.gameObject.SetActive(true);
        _gameOverUI.ShowResult(currentScore);
    }

    public void RestartGame()
    {
        _gameUI.ResetUI();
        _gameUI.gameObject.SetActive(false);
        _gameOverUI.gameObject.SetActive(false);
        _menuUI.gameObject.SetActive(true);

        _player.ResetPlayer();
        spawners.ForEach(spawner => spawner.StopSpawn(Events.StopSpawnEvent));

        EventManager.Broadcast(Events.StartMovingBackgroundEvent);
        EventManager.Broadcast(Events.ReturnToPoolEvent);
    }
}
