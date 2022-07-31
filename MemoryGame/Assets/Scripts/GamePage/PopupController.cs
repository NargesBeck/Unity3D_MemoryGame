using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField]
    private GameObject victoryPopup;
    [SerializeField]
    private GameObject gameOverPopup;

    private void Awake()
    {
        Linker.Instance.CardModel.OnLevelEnd = ShowPopup;
    }

    private void ShowPopup(bool playerWon)
    {
        if (playerWon)
            Instantiate(victoryPopup);
        else
            Instantiate(gameOverPopup);
    }
}
