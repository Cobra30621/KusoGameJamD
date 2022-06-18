using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInteractObject : InteractableObject
{
    public bool isABCD;
    public EventType eventType;
    public override void OnActiveEvent()
    {
        GameManager.instance.PlayEventData(this.name, isABCD);

        // FlowChartManager.PlayEvent(eventType);
        // print(GameManager.instance.ChooseOrder);
        gameObject.SetActive(false);
    }
}
