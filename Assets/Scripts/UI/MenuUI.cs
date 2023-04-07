using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class MenuUI : MonoBehaviour
{
    [Header("Main part")]
    [SerializeField] private GameObject _main;

    [Header("Score part")]
    [SerializeField] private GameObject _score;
    [SerializeField] private TMP_Text _bestScore;

    [Header("Settings part")]
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
        _bestScore.text = "Score: " + PlayerPrefs.GetInt(PlayerPrefsConsts.BEST_SCORE);
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
