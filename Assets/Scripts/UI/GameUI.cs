using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameUI : MonoBehaviour
{
    [Inject] private EventManager _eventManager;

    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _points;
    [SerializeField] private GameObject _pauseButton;

    private void Awake()
    {
        _eventManager.AddListener<PointEvent>(AddPoint);
    }

    public void AddPoint(PointEvent evt)
    {
        Debug.Log("POINTS: " + evt.point);
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
