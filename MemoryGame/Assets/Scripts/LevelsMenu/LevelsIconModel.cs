using UnityEngine;
using System.Collections.Generic;

public class LevelsIconModel : MonoBehaviour
{
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
}
