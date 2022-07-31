using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerModel : MonoBehaviour
{
    private int _secondsRemaining;

    public Action<int> OnTimerUpdate;

    private void Start()
    {
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
        if (_secondsRemaining > 0)
            StartCoroutine(OneSecondDelay());
        else if (Linker.Instance.CardModel.OnLevelEnd != null)
            Linker.Instance.CardModel.OnLevelEnd(false);
    }
}
