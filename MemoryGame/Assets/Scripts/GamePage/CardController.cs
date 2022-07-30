using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.EventSystems;


public class CardController : MonoBehaviour, IPointerClickHandler
{
    public CardStates currentCardState = CardStates.ReadyToBeClicked;

    [SerializeField]
    private Sprite coverSprite, contentSprite;

    private int Index;

    #region buffering Transform And Renderers
    private Transform _myTransform;
    private Transform MyTransform
    {
        get
        {
            if (_myTransform == null)
                _myTransform = GetComponent<Transform>();
            return _myTransform;
        }
    }

    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer SpriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
                _spriteRenderer = GetComponent<SpriteRenderer>();
            return _spriteRenderer;
        }
    }
    #endregion

    private Action<int> OnCardClick;

    public void SetSprite(Sprite content)
    {
        contentSprite = content;
    }

    public void DeactivateMe() => gameObject.SetActive(false);

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentCardState != CardStates.ReadyToBeClicked)
            return;
        currentCardState = CardStates.Flipping;
        StartCoroutine(Flip(contentSprite));
    }

    private IEnumerator Flip(Sprite newSpriteValue)
    {
        float flipDuration = 0.5f;
        MyTransform.DORotate(new Vector3(0, 90, 0), flipDuration / 2);
        yield return new WaitForSecondsRealtime(flipDuration / 2);

        SpriteRenderer.sprite = newSpriteValue;

        MyTransform.DORotate(new Vector3(0, 0, 0), flipDuration / 2);
        yield return new WaitForSecondsRealtime(flipDuration / 2);

        currentCardState = CardStates.DisplayTemporarily;
    }
}
