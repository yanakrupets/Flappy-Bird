using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    [Inject] private Player _player;

    [SerializeField] private GameObject _main;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _points;
    [SerializeField] private GameObject _pauseButton;

    public void OpenPlayGameUI()
    {
        _points.SetActive(true);
        _pauseButton.SetActive(true);
    }

    public void OpenMainMenu()
    {
        _main.SetActive(true);
    }

    public void HideMainMenu()
    {
        _main.SetActive(false);
    }

    public void OpenScore()
    {
        _score.SetActive(true);
    }

    public void HideScore()
    {
        _score.SetActive(false);
    }

    public void OpenSettings()
    {
        _settings.SetActive(true);
    }

    public void HideSettings()
    {
        _settings.SetActive(false);
    }

    public void OpenPause()
    {
        _pause.SetActive(true);
    }

    public void HidePause()
    {
        _pause.SetActive(false);
    }
}
