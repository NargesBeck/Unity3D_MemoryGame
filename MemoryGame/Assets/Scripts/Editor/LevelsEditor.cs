using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelsEditor : EditorWindow
{
    private static List<Level> levelsDB = new List<Level>();
    private static Rect windowSize = new Rect(100, 100, 1000, 600);

    private static Rect columnOne = new Rect(0, 0, 100, 600);
    private static Rect columnTwoHeader = new Rect(columnOne.width + 20, 10, windowSize.width -  columnOne.width - 20 * 2, 50);
    private Vector2 columnOneScrollPos = Vector2.zero;

    private Color editorTheme = Color.cyan;
    private Level selectedLevel;

    [MenuItem("BZdio/LevelsEditor &l")]
    public static void ShowWindow()
    {
        var data = Resources.Load<LevelsScriptableObject>("Data");
        if (data != null)
        {
            levelsDB = data.levels;
        }

        LevelsEditor IdlesWindow = (LevelsEditor)GetWindow(typeof(LevelsEditor));
        IdlesWindow.position = windowSize;
        IdlesWindow.minSize = new Vector2(windowSize.width, windowSize.height);

        IdlesWindow.Show();
    }

    private void OnGUI()
    {
        DrawLevelsListColumn();

        if (selectedLevel == null)
            return;

        DrawHeaderSection();
    }

    private void DrawLevelsListColumn()
    {
        GUILayout.BeginArea(columnOne);
        columnOneScrollPos = GUILayout.BeginScrollView(columnOneScrollPos);
        EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
        EditorGUI.BeginDisabledGroup(false);

        GUI.color = editorTheme;
        if (GUILayout.Button("New Level", GUILayout.MinHeight(50)))
        {
            levelsDB.Add(new Level());
        }

        GUILayout.Label("Levels:");
        GUI.color = Color.white;

        for (int i = 0; i < levelsDB.Count; i++)
        {
            GUI.color = (levelsDB[i] == selectedLevel) ? editorTheme : Color.white;
            if (GUILayout.Button(levelsDB[i].LevelNumber.ToString()))
            {
                GUI.FocusControl(null);
                selectedLevel = levelsDB[i];
            }
        }
        GUI.color = Color.white;

        EditorGUI.EndDisabledGroup();
        EditorGUILayout.EndVertical();
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }

    private void DrawHeaderSection()
    {
        GUILayout.BeginArea(columnTwoHeader);
        EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
        EditorGUI.BeginDisabledGroup(false);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Level Number: ");
        selectedLevel.LevelNumber = EditorGUILayout.IntField(selectedLevel.LevelNumber, GUILayout.MinWidth(50));
        GUILayout.Label("Num of Cards: ");
        selectedLevel.NumOfCards = EditorGUILayout.IntField(selectedLevel.NumOfCards, GUILayout.MinWidth(50));
        GUILayout.Label("Time (Secs): ");
        selectedLevel.TimeInSeconds = EditorGUILayout.IntField(selectedLevel.TimeInSeconds, GUILayout.MinWidth(50));
        GUILayout.EndHorizontal();

        GUI.color = Color.red;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Delete"))
        {
            GUI.FocusControl(null);
            levelsDB.Remove(selectedLevel);
            selectedLevel = null;

            GUILayout.EndHorizontal();
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndVertical();
            GUILayout.EndArea();
            return;
        }
        GUILayout.EndHorizontal();



        EditorGUI.EndDisabledGroup();
        EditorGUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
