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
    [Inject] private EventManager _eventManager;

    // current score ?

    private void Awake()
    {
        
    }

    public void StartGame()
    {
        _spawner.StartSpawn();
        _player.Fly();
        // in method
        _menuUI.gameObject.SetActive(false);
        _gameUI.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        var stopMovementEvent = Events.StopMovementEvent;
        _eventManager.Broadcast(stopMovementEvent);
    }

    public void ContinueGame()
    {
        var continueMovementEvent = Events.ContinueMovementEvent;
        _eventManager.Broadcast(continueMovementEvent);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
