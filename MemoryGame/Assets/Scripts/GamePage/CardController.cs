using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.EventSystems;


public class CardController : MonoBehaviour, IPointerClickHandler
{
    public CardStates CurrentCardState = CardStates.ReadyToBeClicked;

    [SerializeField]
    private Sprite coverSprite;
    public Sprite ContentSprite  {get; set;}

    public int Index { get; set; }

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

    public void DeactivateMe() => gameObject.SetActive(false);

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Linker.Instance.CardModel.OnCardClick != null)
            Linker.Instance.CardModel.OnCardClick(Index);
        else
            throw new ArgumentException("On card click is empty");
    }

    private IEnumerator Flip(Sprite newSpriteValue, float startDelay = 0)
    {
        if (startDelay > 0)
            yield return new WaitForSecondsRealtime(startDelay);

        float flipDuration = 0.5f;
        MyTransform.DORotate(new Vector3(0, 90, 0), flipDuration / 2);
        yield return new WaitForSecondsRealtime(flipDuration / 2);

        SpriteRenderer.sprite = newSpriteValue;

        MyTransform.DORotate(new Vector3(0, 0, 0), flipDuration / 2);
        yield return new WaitForSecondsRealtime(flipDuration / 2);

        if (CurrentCardState == CardStates.FlippingToShow)
            SetNewState(CardStates.Showing);
        else if (CurrentCardState == CardStates.FlippingToHide)
            SetNewState(CardStates.ReadyToBeClicked);
    }

    public void SetNewState(CardStates newState)
    {
        switch (newState)
        {
            case CardStates.FlippingToShow:
                CurrentCardState = newState;
                StartCoroutine(Flip(ContentSprite));
                break;
            case CardStates.FlippingToHide:
                //float delayStart = CurrentCardState == CardStates.FlippingToShow ? 0.5f : 0;
                CurrentCardState = newState;
                StartCoroutine(Flip(coverSprite, 0.5f));
                break;
            default:
                CurrentCardState = newState;
                break;
        }
    }
}
