using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _main;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _settings;

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
}
