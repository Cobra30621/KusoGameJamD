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

    public bool loveRoute;
    public bool wineRoute;

    public List<EventData> eventList;
    public EndingManager endingManager;
    public InfoManager infoManager;
    public WineManager wineManager;
    public GameObject restartButton;
    public GameObject FavorableEffectUIBar;

    public delegate void EndValueChangeEvent();
    public event EndValueChangeEvent OnEndValueChange;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Init();
    }

    public void Init()
    {

        ChooseOrder = "";
        ChooseCount = 0;
        loveRoute = false;

        restartButton.SetActive(false);
        wineManager.CloseBlurEffect();
        SoundManager.Instance.Stop(); // 重啟關掉聲音
    }

    public void ReStart(){
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

            OnEndValueChange();
            // 判斷是否撥放結局
            if (eventData.isEnding)
                PlayEnding(eventData.DoEvent);
            else{
                FlowChartManager.PlayEvent(eventData.DoEvent);
                if(eventData.DoEvent != EventType.Wine)
                    infoManager.ShowInfo(eventData.text);
            }
        }
    }

    public void CheckWhetherPlayEnding(){
        if(ChooseCount == 4){
            PlayEnding(EventType.JudgeEnd);
        }
    }

    public void PlayEnding(EventType eventType){
        
        // ABCD 判斷    
        Ending ending = Ending.SingEnd;
        int max = End_A_Effect;
        if(End_B_Effect > max)
        {
            ending = Ending.TakeSignEnd;
            max = End_B_Effect;
        }
        if(End_C_Effect > max)
        {
            ending = Ending.DirtyJokeEnd;
            max = End_C_Effect;
        }
        if(End_D_Effect > max) ending = Ending.GameEnd;

        // 戀愛路線
        if(loveRoute){
            if(FavorableEffect >= NeedFavorableEffect)
                ending = Ending.LoveSuccessEnd;
            else
                ending = Ending.LoveFalseEnd;
        }

        // 特殊結局
        if(eventType == EventType.KusoEnd) ending = Ending.KusoEnd;
        if(eventType == EventType.WineEnd) ending = Ending.WineEnd;
        if(eventType == EventType.LeaveEnd) ending = Ending.LeaveEnd;

        
        endingManager.SetCurrentEnd(ending);
        FlowChartManager.PlayEnd(ending);
        // FlowChartManager.PlayBlockByString("AfterEnd");
        
        endingManager.GainEnd(ending);

    }

    public void CloseWineEffect(){
        wineManager.Clear(); // 結束倒數
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

    public void StartLoveRoute(){
        Debug.Log("StartLoveRoute");
        FavorableEffectUIBar.SetActive(true);
        loveRoute = true;
    }

    public void StartWineRoute(){
        Debug.Log("StartWineRoute");
        wineRoute = true;
        wineManager.gameObject.SetActive(true);
    }

}
