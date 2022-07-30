using UnityEngine;

namespace MemoryMatch.Controller
{
    public class MainMenuController : MonoBehaviour
    {
        public void OnPlayButtonClick()
        {
            GameManager.Instance.ChangeScene(GameManager.GameScenes.SceneLevelsMenu);
        }
    }
}