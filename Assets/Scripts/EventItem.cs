using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventItem : InteractableObject
{
    public override void OnActiveEvent()
    {
        print("active");
    }

}
