using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerModel : MonoBehaviour
{
    private new bool enabled = true;
    private int _secondsRemaining;

    public Action<int> OnTimerUpdate;

    private void Start()
    {
        Linker.Instance.CardModel.OnLevelEnd += LevelEnded;
        AssignMe();
    }

    private void AssignMe()
    {
        _secondsRemaining = GameManager.Instance.CurrentLevel.TimeInSeconds;
        if (OnTimerUpdate != null)
            OnTimerUpdate(_secondsRemaining);
        StartCoroutine(OneSecondDelay());
    }

    private IEnumerator OneSecondDelay()
    {
        yield return new WaitForSeconds(1);
        _secondsRemaining--;
        if (OnTimerUpdate != null)
            OnTimerUpdate(_secondsRemaining);
        if (_secondsRemaining > 0 && enabled)
            StartCoroutine(OneSecondDelay());
        else if (Linker.Instance.CardModel.OnLevelEnd != null && enabled)
            Linker.Instance.CardModel.OnLevelEnd(false);
    }

    private void LevelEnded(bool playerWon)
    {
        if (playerWon)
        {
            enabled = false;
            StopCoroutine(OneSecondDelay());
        }
    }
}
