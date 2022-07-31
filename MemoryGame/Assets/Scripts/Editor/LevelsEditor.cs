using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelsEditor : EditorWindow
{
    private static List<Level> levelsDB;
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
        DrawCards();
        ApplyChanges();
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

        if (selectedLevel.CardsContents.Count > selectedLevel.NumOfCards)
        {
            selectedLevel.CardsContents.RemoveRange(selectedLevel.NumOfCards, selectedLevel.CardsContents.Count - selectedLevel.NumOfCards);
        }
        else if (selectedLevel.CardsContents.Count < selectedLevel.NumOfCards)
        {
            for (int i = 0; i < selectedLevel.NumOfCards; selectedLevel.CardsContents.Add(0), i++) ;
        }

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
            GUI.color = Color.white;
            GUILayout.EndHorizontal();
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndVertical();
            GUILayout.EndArea();
            return;
        }
        GUI.color = Color.white;
        GUILayout.EndHorizontal();

        EditorGUI.EndDisabledGroup();
        EditorGUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private void DrawCard(Rect pos, int cardIndex)
    {
        GUILayout.BeginArea(pos);
        EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Duck: ");
        selectedLevel.CardsContents[cardIndex] = EditorGUILayout.IntField(selectedLevel.CardsContents[cardIndex], GUILayout.MinWidth(20));
        GUILayout.EndHorizontal();

        Sprite sprite = GameManager.Instance.CardsContentDB.GetSpriteByIndex(selectedLevel.CardsContents[cardIndex]);
        GUI.DrawTexture(new Rect(12, 30, 80, 80), sprite.texture);
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private void DrawCards()
    {

        /* [0,0]
         *     11   5   4  10
         * 15   9   0   1   8  13
         * 14   7   2   3   6  12
         */
        
        if (selectedLevel.NumOfCards > 14)
            DrawCard(CalcCardPos(2, 0), 14);
        if (selectedLevel.NumOfCards > 7)
            DrawCard(CalcCardPos(2, 1), 7); 
        if (selectedLevel.NumOfCards > 2)
            DrawCard(CalcCardPos(2, 2), 2); 
        if (selectedLevel.NumOfCards > 3)
            DrawCard(CalcCardPos(2, 3), 3); 
        if (selectedLevel.NumOfCards > 6)
            DrawCard(CalcCardPos(2, 4), 6); 
        if (selectedLevel.NumOfCards > 12)
            DrawCard(CalcCardPos(2, 5), 12);


        if (selectedLevel.NumOfCards > 15)
            DrawCard(CalcCardPos(1, 0), 15);
        if (selectedLevel.NumOfCards > 9)
            DrawCard(CalcCardPos(1, 1), 9);
        if (selectedLevel.NumOfCards > 0)
            DrawCard(CalcCardPos(1, 2), 0);
        if (selectedLevel.NumOfCards > 1)
            DrawCard(CalcCardPos(1, 3), 1);
        if (selectedLevel.NumOfCards > 8)
            DrawCard(CalcCardPos(1, 4), 8);
        if (selectedLevel.NumOfCards > 13)
            DrawCard(CalcCardPos(1, 5), 13);

        if (selectedLevel.NumOfCards > 11)
            DrawCard(CalcCardPos(0, 1), 11);
        if (selectedLevel.NumOfCards > 5)
            DrawCard(CalcCardPos(0, 2), 5);
        if (selectedLevel.NumOfCards > 4)
            DrawCard(CalcCardPos(0, 3), 4);
        if (selectedLevel.NumOfCards > 10)
            DrawCard(CalcCardPos(0, 4), 10);
    }

    private Rect CalcCardPos(int row, int col)
    {
        float cardWidthHeight = 110, baseX = 200, baseY = 150;
        float x = baseX + col * cardWidthHeight;
        float y = baseY + row * cardWidthHeight;
        return new Rect(x, y, cardWidthHeight, cardWidthHeight);
    }
    private void ApplyChanges()
    {
        var data = Resources.Load<LevelsScriptableObject>("Data");
        if (data != null)
        {
            data.levels = levelsDB;
            EditorUtility.SetDirty(data);
        }
    }
}