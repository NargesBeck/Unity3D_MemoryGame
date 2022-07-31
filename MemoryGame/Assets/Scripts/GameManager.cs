using UnityEngine;
using UnityEngine.SceneManagement;

public enum CardStates
{
    ReadyToBeClicked, FlippingToShow, FlippingToHide, Showing
}

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager s_instance;
    public static GameManager Instance
    {
        get 
        { 
            if (s_instance == null)
                s_instance = FindObjectOfType<GameManager>();
            return s_instance;
        }
    }

    private CardsContentDB _cardsContentDB;
    public CardsContentDB CardsContentDB
    {
        get
        {
            if (_cardsContentDB == null)
                _cardsContentDB = GetComponent<CardsContentDB>();
            return _cardsContentDB;
        }
    }

    public enum GameScenes
    {
        SceneMainMenu, SceneLevelsMenu, SceneGamePage
    }

    private GameScenes _currentState = GameScenes.SceneMainMenu;

    public Level CurrentLevel;

    private void Awake()
    {
        DontDestroyOnLoad(Instance.gameObject);
    }

    public void ChangeScene(GameScenes changeTo)
    {
        _currentState = changeTo;
        SceneManager.LoadScene((int) changeTo);
    }
}
