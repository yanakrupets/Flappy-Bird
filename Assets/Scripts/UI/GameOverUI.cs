using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _bestScore;

    public void ShowResult(int score)
    {
        _score.text = "Score\n" + score;
        _bestScore.text = "Best\n" + PlayerPrefs.GetInt(PlayerPrefsConsts.BEST_SCORE);
    }
}
