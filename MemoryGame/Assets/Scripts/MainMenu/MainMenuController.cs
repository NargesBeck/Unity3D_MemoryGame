using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance.PreviewingLevelToTest)
        {
            GameManager.Instance.ChangeScene(GameManager.GameScenes.SceneGamePage);
            GameManager.Instance.PreviewingLevelToTest = false;
        }
    }

    public void OnPlayButtonClick()
    {
        GameManager.Instance.ChangeScene(GameManager.GameScenes.SceneLevelsMenu);
    }
}