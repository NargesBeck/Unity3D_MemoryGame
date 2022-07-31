using UnityEngine;
using System;
using System.Collections.Generic;

public class CardModel : MonoBehaviour
{
    public Action<int> OnCardClick;

    private List<CardController> clickedCards = new List<CardController> ();

    private void Awake()
    {
        OnCardClick = HandleClick;
    }

    private void HandleClick(int index)
    {
        if (clickedCards.Count > 2)
            return;

        CardController clickedCardController = Linker.Instance.CardsPoolModel.GetCardControllerByIndex(index);
        if (clickedCardController == null)
        {
            throw new ArgumentException("Invalid index returned by card");
        }

        clickedCards.Add(clickedCardController);
        if (clickedCardController.CurrentCardState == CardStates.ReadyToBeClicked)
            clickedCardController.SetNewState(CardStates.FlippingToShow);

        if (clickedCards.Count == 2)
            CheckIfMatch();
    }

    private void CheckIfMatch()
    {
        if (clickedCards[0].ContentSprite == clickedCards[1].ContentSprite)
        {
            // score

        }
        else
        {
            clickedCards[0].SetNewState(CardStates.FlippingToHide);
            clickedCards[1].SetNewState(CardStates.FlippingToHide);
        }
        clickedCards.Clear();
    }
}
