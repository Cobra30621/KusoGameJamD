using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string ChooseOrder;

    public int FavorableEffect;
    public int End_A_Effect;
    public int End_B_Effect;
    public int End_C_Effect;
    public int End_D_Effect;

    public List<EventData> eventList;


    void Start()
    {
        instance = this;
        ReStart();
    }

    void Update()
    {
        
    }

    public void ReStart()
    {
        ChooseOrder = "";
    }

    public void PlayEventData(string id){
        ChooseOrder += id;
        EventData eventData = GetEventData(ChooseOrder);

        if(eventData != null){
            FavorableEffect += eventData.FavorableEffect;
            End_A_Effect += eventData.End_A_Effect;
            End_B_Effect += eventData.End_B_Effect;
            End_C_Effect += eventData.End_C_Effect;
            End_D_Effect += eventData.End_D_Effect;

            FlowChartManager.PlayEvent(eventData.DoEvent);
        }
    }

    public EventData GetEventData(string id){
        foreach (EventData eventData in eventList){
            if(eventData.ID == id){
                Debug.Log($"取得事件:{id}");
                return eventData;
            }
            
        }
        Debug.Log($"沒有事件:{id}");
        return null;
    }
}
