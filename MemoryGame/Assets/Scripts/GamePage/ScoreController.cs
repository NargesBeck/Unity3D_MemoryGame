using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreController : MonoBehaviour
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

    [SerializeField]
    private Transform _textMeshTransform;
    #endregion

    Sequence sequence;
    private void Awake()
    {
        Linker.Instance.ScoreModel.OnScoreUpdate = UpdateScore;
    }

    private void UpdateScore(int newScore)
    {
        Text.text = newScore.ToString();
        RectTransform.DOShakeScale(1);
        sequence = DOTween.Sequence();
        sequence.Append(_textMeshTransform.DOScale(new Vector3(1, 1, 1), 0.5f));
        sequence.Append(_textMeshTransform.DOScale(new Vector3(0, 0, 0), 0.25f));
    }
}
