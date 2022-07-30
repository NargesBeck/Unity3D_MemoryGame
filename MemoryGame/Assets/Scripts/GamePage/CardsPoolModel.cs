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
                cardControllers[i].SetSprite(GameManager.Instance.CardsContentDB.GetSpriteByIndex(GameManager.Instance.CurrentLevel.CardsContents[i]));
            }
            else
            {
                cardControllers[i].DeactivateMe();
            }
        }
    }
}
