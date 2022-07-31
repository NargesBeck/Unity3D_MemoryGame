using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Levels", order = 1)]
public class LevelsScriptableObject : ScriptableObject
{
    public List<Level> levels = new List<Level>();
}

[Serializable]
public class Level
{
    public int LevelNumber;
    public int NumOfCards;
    public int TimeInSeconds;
    public List<int> CardsContents = new List<int>();
}