using UnityEngine;
using System.Collections.Generic;

public class LevelsIconModel : MonoBehaviour
{
    private static LevelsIconModel s_instance;
    public static LevelsIconModel Instance
    {
        get
        { 
            if (s_instance == null)
                s_instance = FindObjectOfType<LevelsIconModel>();
            return s_instance; 
        }
    }

    private List<Level> levels = new List<Level>();

    [SerializeField]
    private List<LevelIconController> _levelControllers = new List<LevelIconController>();

    private void Start()
    {
        LoadScriptableObject();
        AssignLevelControllers();
    }

    private void LoadScriptableObject()
    {
        var objectDB = Resources.Load<LevelsScriptableObject>("Data");
        if (objectDB != null)
        {
            levels = objectDB.levels;
        }
    }

    private void AssignLevelControllers()
    {
        for (int i = 0; i < _levelControllers.Count; i++)
        {
            var controller = _levelControllers[i];
            if (i < levels.Count)
            {
                controller.AssignMe(levels[i].LevelNumber, levels[i].NumOfCards, levels[i].TimeInSeconds);
            }
            else
            {
                controller.DeactivateMe();
            }
        }
    }

    public Level GetLevelByButtonIndex(int buttonIndex, out bool isValid)
    {
        isValid = false;
        if (buttonIndex < 0 || buttonIndex >= levels.Count)
            return default;
        isValid = true;
        return levels[buttonIndex];
    }
}
