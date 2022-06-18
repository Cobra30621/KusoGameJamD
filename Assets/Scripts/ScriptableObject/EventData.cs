using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Event Data")]
public class EventData : ScriptableObject
{
    public string ID;
    public EventType DoEvent;
    public int FavorableEffect;
    public int End_A_Effect;
    public int End_B_Effect;
    public int End_C_Effect;
    public int End_D_Effect;
}
