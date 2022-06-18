using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInteractObject : InteractableObject
{
    public EventType eventType;
    public override void OnActiveEvent()
    {
        
        
        GameManager.instance.PlayEventData(this.name);
        // FlowChartManager.PlayEvent(eventType);
        print(GameManager.instance.ChooseOrder);
        gameObject.SetActive(false);
    }
}
