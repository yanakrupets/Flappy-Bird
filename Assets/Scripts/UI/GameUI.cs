using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _points;
    [SerializeField] private GameObject _pauseButton;

    public void OpenPause()
    {
        _pause.SetActive(true);
    }

    public void HidePause()
    {
        _pause.SetActive(false);
    }
}
