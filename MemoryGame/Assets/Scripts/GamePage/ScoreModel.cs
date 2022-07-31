using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    private int score;
    private const int scoreIncrementValue = 50;
    public Action<int> OnScoreUpdate;

    private void Awake()
    {
        Linker.Instance.CardModel.OnCardsMatch = UpdateScoreOnMatch;
    }

    private void UpdateScoreOnMatch()
    {
        score += scoreIncrementValue;
        if (OnScoreUpdate != null)
            OnScoreUpdate(score);
    }
}
