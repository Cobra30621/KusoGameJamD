using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public EndingManager endingManager;
    public Ending ending;
    // Start is called before the first frame update
    void Start()
    {
        // FlowChartManager.PlayEvent("A");
    }


    public EventType testEvent;
    [ContextMenu("Test")]
    public void Testing(){
        Debug.Log(testEvent.ToString());
        FlowChartManager.PlayEvent(testEvent);
        // endingManager.GetEnd(ending);
    }
    
}
