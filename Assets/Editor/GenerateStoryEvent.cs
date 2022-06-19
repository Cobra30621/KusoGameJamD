using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class GenerateStoryEvent : Editor
{
    
    [MenuItem("Tools/Generate Story Event Assets")]
    public static void GenerateStoryEventAssets()
    {
        
        StoryEventData storyEventData = new StoryEventData();
        string[] EventID = { "A", "B", "C", "D" };
        int num;
        for (int i = 0; i < 4; i++)
        {
            string useID_i;
            List<string> ID_i = new List<string>(EventID);
            useID_i = ID_i[i];
            EventData eventData = CreateInstance<EventData>();
            eventData.DoEvent = (EventType)storyEventData.Event[ID_i[i]];
            eventData.FavorableEffect = (int)((Array)(storyEventData.GetType().GetField(EventID[i] + "_FavorableEffect").GetValue(storyEventData))).GetValue(i);
            eventData.End_A_Effect = (int)((Array)(storyEventData.GetType().GetField(EventID[i] + "_End_A_Effect").GetValue(storyEventData))).GetValue(i);
            eventData.End_B_Effect = (int)((Array)(storyEventData.GetType().GetField(EventID[i] + "_End_B_Effect").GetValue(storyEventData))).GetValue(i);
            eventData.End_C_Effect = (int)((Array)(storyEventData.GetType().GetField(EventID[i] + "_End_C_Effect").GetValue(storyEventData))).GetValue(i);
            eventData.End_D_Effect = (int)((Array)(storyEventData.GetType().GetField(EventID[i] + "_End_D_Effect").GetValue(storyEventData))).GetValue(i);
            ID_i.RemoveAt(i);
            AssetDatabase.CreateAsset(eventData, "Assets/GameData/MainEvent/" + useID_i + ".asset");
            AssetDatabase.SaveAssets();

            for (int j = 0; j < 3; j++)
            {
                string useID_j = String.Copy(useID_i);
                List<string> ID_j = new List<string>(ID_i);
                useID_j += ID_j[j];
                eventData = CreateInstance<EventData>();
                eventData.DoEvent = (EventType)storyEventData.Event[ID_j[j]];
                eventData.FavorableEffect = (int)((Array)(storyEventData.GetType().GetField(ID_j[j] + "_FavorableEffect").GetValue(storyEventData))).GetValue(1);
                eventData.End_A_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_j[j] + "_End_A_Effect").GetValue(storyEventData))).GetValue(1);
                eventData.End_B_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_j[j] + "_End_B_Effect").GetValue(storyEventData))).GetValue(1);
                eventData.End_C_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_j[j] + "_End_C_Effect").GetValue(storyEventData))).GetValue(1);
                eventData.End_D_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_j[j] + "_End_D_Effect").GetValue(storyEventData))).GetValue(1);
                AssetDatabase.CreateAsset(eventData, "Assets/GameData/MainEvent/" + useID_j + ".asset");
                AssetDatabase.SaveAssets();
                ID_j.RemoveAt(j);

                for (int n = 0; n < 2; n++)
                {
                    string useID_n = String.Copy(useID_j);
                    List<string> ID_n = new List<string>(ID_j);
                    useID_n += ID_n[n];
                    eventData = CreateInstance<EventData>();
                    eventData.DoEvent = (EventType)storyEventData.Event[ID_n[n]];
                    eventData.FavorableEffect = (int)((Array)(storyEventData.GetType().GetField(ID_n[n] + "_FavorableEffect").GetValue(storyEventData))).GetValue(2);
                    eventData.End_A_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_n[n] + "_End_A_Effect").GetValue(storyEventData))).GetValue(2);
                    eventData.End_B_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_n[n] + "_End_B_Effect").GetValue(storyEventData))).GetValue(2);
                    eventData.End_C_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_n[n] + "_End_C_Effect").GetValue(storyEventData))).GetValue(2);
                    eventData.End_D_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_n[n] + "_End_D_Effect").GetValue(storyEventData))).GetValue(2);
                    AssetDatabase.CreateAsset(eventData, "Assets/GameData/MainEvent/" + useID_n + ".asset");
                    AssetDatabase.SaveAssets();
                    ID_n.RemoveAt(n);

                    useID_n += ID_n[0];
                    eventData = CreateInstance<EventData>();
                    eventData.DoEvent = (EventType)storyEventData.Event[ID_n[0]];
                    eventData.FavorableEffect = (int)((Array)(storyEventData.GetType().GetField(ID_n[0] + "_FavorableEffect").GetValue(storyEventData))).GetValue(3);
                    eventData.End_A_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_n[0] + "_End_A_Effect").GetValue(storyEventData))).GetValue(3);
                    eventData.End_B_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_n[0] + "_End_B_Effect").GetValue(storyEventData))).GetValue(3);
                    eventData.End_C_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_n[0] + "_End_C_Effect").GetValue(storyEventData))).GetValue(3);
                    eventData.End_D_Effect = (int)((Array)(storyEventData.GetType().GetField(ID_n[0] + "_End_D_Effect").GetValue(storyEventData))).GetValue(3);
                    AssetDatabase.CreateAsset(eventData, "Assets/GameData/MainEvent/" + useID_n + ".asset");
                    AssetDatabase.SaveAssets();
                }
            }
        }
        AssetDatabase.Refresh();
    }

    class StoryEventData
    {
        public Hashtable Event = new Hashtable();
        public StoryEventData()
        {
            Event.Add("A", EventType.Sing);
            Event.Add("B", EventType.TakeSign);
            Event.Add("C", EventType.DirtyJoke);
            Event.Add("D", EventType.Game);
        }

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
