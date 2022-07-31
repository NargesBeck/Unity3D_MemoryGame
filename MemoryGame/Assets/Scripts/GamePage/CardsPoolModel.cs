using System.Collections.Generic;
using UnityEngine;

public class CardsPoolModel : MonoBehaviour
{
    [SerializeField]
    private List<CardController> cardControllers = new List<CardController>();

    private void Start()
    {
        AssignCards(GameManager.Instance.CurrentLevel);
    }

    public void AssignCards(Level level)
    {
        for (int i = 0; i < cardControllers.Count; i++)
        {
            if (i < level.NumOfCards)
            {
                cardControllers[i].ContentSprite = GameManager.Instance.CardsContentDB.GetSpriteByIndex(GameManager.Instance.CurrentLevel.CardsContents[i]);
                cardControllers[i].Index = i;
            }
            else
            {
                cardControllers[i].DeactivateMe();
            }
        }
    }

    public CardController GetCardControllerByIndex(int index)
    {
        if (index < 0 || index >= cardControllers.Count)
            return null;
        return cardControllers[index];
    }
}
