using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using System;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;
using System.Threading;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _pausePopup;
    [SerializeField] private TMP_Text _points;

    [Header("Catched Bonus")]
    [SerializeField] private GameObject _bonus;
    [SerializeField] private TMP_Text _bonusName;
    [SerializeField] private Image _bonusImage;

    private void Awake()
    {
        EventManager.AddListener<PointEvent>(AddPoint);
        EventManager.AddListener<BonusEvent>(ShowCatchedBonus);
    }

    public void ResetUI()
    {
        _points.text = "0";
        HidePause();
    }

    public void ShowCatchedBonus(BonusEvent evt)
    {
        _bonus.gameObject.SetActive(true);

        _bonusName.text = evt.bonusData.Name;
        _bonusImage.sprite = evt.bonusData.Sprite;

        var sequence = DOTween.Sequence();

        sequence.Append(_bonus.transform.DOScale(2f, 0.5f))
            .Append(_bonus.transform.DOScale(1f, 0.5f))
            .OnComplete(() => _bonus.SetActive(false));
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
