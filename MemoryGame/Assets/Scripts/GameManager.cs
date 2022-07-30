using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get 
        { 
            if (instance == null)
                instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }

    public enum GameScenes
    {
        SceneMainMenu, SceneLevelsMenu, SceneGamePage
    }

    private GameScenes currentState = GameScenes.SceneMainMenu;

    private void Awake()
    {
        DontDestroyOnLoad(Instance);
    }

    public void ChangeScene(GameScenes changeTo)
    {
        currentState = changeTo;
        SceneManager.LoadScene((int) changeTo);
    }
}
