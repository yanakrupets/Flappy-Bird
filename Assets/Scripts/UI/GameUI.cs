using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using System;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _pausePopup;
    [SerializeField] private TMP_Text _points;

    private void Awake()
    {
        EventManager.AddListener<PointEvent>(AddPoint);
    }

    public void AddPoint(PointEvent evt)
    {
        var count = Convert.ToInt32(_points.text);
        _points.text = (count + evt.point).ToString();
    }

    public void OpenPause()
    {
        _pausePopup.SetActive(true);
    }

    public void HidePause()
    {
        _pausePopup.SetActive(false);
    }
}
