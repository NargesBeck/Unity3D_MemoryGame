using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupModel : MonoBehaviour
{
    [SerializeField]
    private GameObject victoryPopup;
    [SerializeField]
    private GameObject gameOverPopup;

    private void Awake()
    {
        Linker.Instance.CardModel.OnLevelEnd += ShowPopup;
    }

    private void ShowPopup(bool playerWon)
    {
        if (playerWon)
            StartCoroutine(InstantiateWithDelay(victoryPopup));
        else
            Instantiate(gameOverPopup);
    }

    private IEnumerator InstantiateWithDelay(GameObject gameObject, float delay = 0.75f)
    {
        yield return new WaitForSecondsRealtime(delay);
        Instantiate(gameObject);
    }
}
