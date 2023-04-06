using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private Player _player;
    [Inject] private UIController _UIController;
    [Inject] private Spawner _spawner;

    public void StartGame()
    {
        _spawner.StartSpawn();
        _player.StartFly();
        _UIController.OpenPlayGameUI();
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
