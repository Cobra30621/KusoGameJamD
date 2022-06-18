using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateStoryEvent : Editor
{
    
    [MenuItem("Tools/Generate Story Event Assets")]
    public static void GenerateStoryEventAssets()
    {
        string[] EventID = { "A", "B", "C", "D" };
        for (int i = 0; i < 4; i++)
        {
            for(int j = i + 1; i < 4; j++)
            {
                for(int n = j + 1; n < 4; n++)
                {
                    for (int m = j + 1; m < 4; m++)
                    {
                        EventData eventData = CreateInstance<EventData>();
                        AssetDatabase.CreateAsset(eventData, "Assets/GameData/Event/" + EventID[i] + EventID[j] + EventID[n] + EventID[m]);
                        AssetDatabase.SaveAssets();
                    }
                }
            }
        }
        AssetDatabase.Refresh();
    }

    class StoryEventData
    {
        public int[] A_FavorableEffect = { 30, 10, 0, 0 };
        public int[] A_End_A_Effect = { 80, 50, 25, 0 };
        public int[] A_End_B_Effect = { 0, 0, 0, 0 };
        public int[] A_End_C_Effect = { 0, 0, 0, 0 };
        public int[] A_End_D_Effect = { 0, 0, 0, 0 };

        public int[] B_FavorableEffect = { 30, 10, 0, 0 };
        public int[] B_End_A_Effect = { 0, 0, 0, 0 };
        public int[] B_End_B_Effect = { 0, 0, 0, 0 };
        public int[] B_End_C_Effect = { 0, 0, 0, 0 };
        public int[] B_End_D_Effect = { 0, 0, 0, 0 };

        public int[] C_FavorableEffect = { 30, 10, 0, 0 };
        public int[] C_End_A_Effect = { 0, 0, 0, 0 };
        public int[] C_End_B_Effect = { 0, 0, 0, 0 };
        public int[] C_End_C_Effect = { 0, 0, 0, 0 };
        public int[] C_End_D_Effect = { 0, 0, 0, 0 };

        public int[] D_FavorableEffect = { 30, 10, 0, 0 };
        public int[] D_End_A_Effect = { 0, 0, 0, 0 };
        public int[] D_End_B_Effect = { 0, 0, 0, 0 };
        public int[] D_End_C_Effect = { 0, 0, 0, 0 };
        public int[] D_End_D_Effect = { 0, 0, 0, 0 };
    }
}
