using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        GameManager.Instance.ChangeScene(GameManager.GameScenes.SceneLevelsMenu);
    }
}