using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private Slider _soundSlider;

    [Inject] private SoundManager _soundMananger;

    private void Start()
    {
        _soundMananger.AdjustSoundVolume(PlayerPrefs.GetFloat(PlayerPrefsConsts.SOUND_VOLUME));
        _soundSlider.value = PlayerPrefs.GetFloat(PlayerPrefsConsts.SOUND_VOLUME);
    }

    public void OpenMainMenu()
    {
        _soundMananger.PlayButtonSound();
        _main.SetActive(true);
    }

    public void HideMainMenu()
    {
        _soundMananger.PlayButtonSound();
        _main.SetActive(false);
    }

    public void OpenScore()
    {
        _soundMananger.PlayButtonSound();
        _score.SetActive(true);
        _bestScore.text = "Score: " + PlayerPrefs.GetInt(PlayerPrefsConsts.BEST_SCORE);
    }

    public void HideScore()
    {
        _soundMananger.PlayButtonSound();
        _score.SetActive(false);
    }

    public void OpenSettings()
    {
        _soundMananger.PlayButtonSound();
        _settings.SetActive(true);
    }

    public void HideSettings()
    {
        _soundMananger.PlayButtonSound();
        _settings.SetActive(false);
    }

    public void SoundToggleChange()
    {
        var value = _soundToggle.isOn ? _soundSlider.value : 0;
        _soundMananger.AdjustSoundVolume(value);
    }

    public void SoundValueChange()
    {
        if (_soundToggle.isOn)
            _soundMananger.AdjustSoundVolume(_soundSlider.value);
    }
}
