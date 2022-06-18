using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string ChooseOrder;
    public int ChooseCount;

    public int FavorableEffect;
    public int NeedFavorableEffect;
    public int End_A_Effect;
    public int End_B_Effect;
    public int End_C_Effect;
    public int End_D_Effect;

    public bool Love_route;

    public List<GameObject> interActiveObjectList;
    public List<EventData> eventList;
    public EndingManager endingManager;
    public GameObject restartButton;


    void Start()
    {
        instance = this;
        Init();
    }

    void Update()
    {
        
    }

    public void Init()
    {

        ChooseOrder = "";
        ChooseCount = 0;
        Love_route = false;

        foreach (GameObject go in interActiveObjectList){
            go.SetActive(true);
        }

        endingManager.CloseAllEndImage();
        restartButton.SetActive(false);
    }

    public void ReLoad(){
        SceneManager.LoadScene("Main");
    }

    public void PlayEventData(string id , bool isABCD){
        
        EventData eventData = null;
        
        if(isABCD){
            ChooseOrder += id;
            ChooseCount ++ ;
            eventData = GetEventData(ChooseOrder);
        }
        else 
            eventData = GetEventData(id);

        if(eventData != null){
            FavorableEffect += eventData.FavorableEffect;
            End_A_Effect += eventData.End_A_Effect;
            End_B_Effect += eventData.End_B_Effect;
            End_C_Effect += eventData.End_C_Effect;
            End_D_Effect += eventData.End_D_Effect;

            // 判斷是否撥放結局
            if(eventData.isEnding)
                PlayEnding(eventData.DoEvent);
            else{
                FlowChartManager.PlayEvent(eventData.DoEvent);
            }
        }
    }

    public void CheckWhetherPlayEnd(){
        if(ChooseCount == 4){
            PlayEnding(EventType.JudgeEnd);
        }
    }

    public void PlayEnding(EventType eventType){
        
        // ABCD 判斷    
        Ending ending = Ending.SingEnd;

        if(End_B_Effect > End_A_Effect) ending = Ending.TakeSignEnd;
        if(End_C_Effect > End_B_Effect) ending = Ending.DirtyJokeEnd;
        if(End_D_Effect > End_C_Effect) ending = Ending.GameEnd;

        // 戀愛入線
        if(Love_route){
            if(FavorableEffect >= NeedFavorableEffect)
                ending = Ending.LoveSuccessEnd;
            else
                ending = Ending.LoveFalseEnd;
        }

        // 特殊結局
        if(eventType == EventType.KusoEnd) ending = Ending.KusoEnd;
        if(eventType == EventType.WineEnd) ending = Ending.WineEnd;
        if(eventType == EventType.LeaveEnd) ending = Ending.LeaveEnd;

        
        endingManager.ShowEndImage(ending);
        FlowChartManager.PlayEnd(ending);
        // FlowChartManager.PlayBlockByString("AfterEnd");
        endingManager.GetEnd(ending);

    }

    public EventData GetEventData(string id){
        foreach (EventData eventData in eventList){
            if(eventData.name == id){
                Debug.Log($"取得事件:{id}");
                return eventData;
            }
            
        }
        Debug.Log($"沒有事件:{id}");
        return null;
    }
}
