using UnityEngine;

public class PopupController : MonoBehaviour
{
    public void OnHomeButtonClick()
    {
        GameManager.Instance.ChangeScene(GameManager.GameScenes.SceneLevelsMenu);
    }
}
