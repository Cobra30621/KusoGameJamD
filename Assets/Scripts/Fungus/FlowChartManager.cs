using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowChartManager : MonoBehaviour
{
    public static FlowChartManager instance;
    public Flowchart m_flowchart;
    public string testBlock;
    public static bool isPlaying;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    [ContextMenu("Test Block")]
    public void TestBlock(){
        PlayBlock(testBlock);
    }

    public static void PlayEnd(Ending eventType){
        instance.PlayBlock(eventType.ToString());
    }

    public static void PlayEvent(EventType eventType){
        instance.PlayBlock(eventType.ToString());
    }

    private void PlayBlock(string block){
        UseFungus.PlayBlock( m_flowchart ,block );
    }

    public static void SetIsPlaying(bool bo){
        isPlaying = bo;
    }
}

[System.Serializable]
public enum EventType{
    Sing , TakeSign , DirtyJoke, Game, 
    LoveLetter, Kuso, Wine, Leave, 
    JudgeEnd, KusoEnd, WineEnd, LeaveEnd
}
