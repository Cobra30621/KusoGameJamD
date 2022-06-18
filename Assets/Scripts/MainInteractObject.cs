using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInteractObject : InteractableObject
{
    public override void OnActiveEvent()
    {
        GameManager.instance.ChooseOrder += this.name;
        print(GameManager.instance.ChooseOrder);
    }
}
