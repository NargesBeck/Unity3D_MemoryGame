using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelIconController : MonoBehaviour
{
    [SerializeField]
    private Text _levelNumberText, _levelInfoText;

    public void AssignMe(int levelNumber, int numOfCards, int timeframe)
    {
        _levelNumberText.text = levelNumber.ToString();
        _levelInfoText.text = $"{numOfCards} - 00:{timeframe}";
    }

    public void DeactivateMe()
    {
        gameObject.SetActive(false);
    }

    public void OnClick(int buttonIndex)
    {
        Level clickedLevel = LevelsIconModel.Instance.GetLevelByButtonIndex(buttonIndex, out bool isValid);
        if (isValid)
        {
            GameManager.Instance.CurrentLevel = clickedLevel;
            GameManager.Instance.ChangeScene(GameManager.GameScenes.SceneGamePage);
        }
        else
        {
            throw new ArgumentException("No level found for this button.");
        }
    }
}
