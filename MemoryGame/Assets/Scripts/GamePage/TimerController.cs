using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    #region Buffering components
    [SerializeField]
    private RectTransform _rectTransform;
    private RectTransform RectTransform
    {
        get
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
            return _rectTransform;
        }
    }

    [SerializeField]
    private Text _text;
    private Text Text
    {
        get
        {
            if (_text == null)
                _text = GetComponent<Text>();
            return _text;
        }
    }
    #endregion

    private void Awake()
    {
        Linker.Instance.TimerModel.OnTimerUpdate = UpdateTimer;
    }

    private void UpdateTimer(int newValue)
    {
        int min = newValue / 60;
        int sec = newValue - newValue * min;
        string timeStr = "";
        if (sec < 10)
            timeStr = $"0{min}:0{sec}";
        else
            timeStr = $"0{min}:{sec}";
        Text.text = timeStr;

        if (newValue < 5)
            UrgencyMode();
    }

    private void UrgencyMode()
    {
        Text.color = Color.red;
        RectTransform.DOShakeScale(5, 0.1f);
    }
}
