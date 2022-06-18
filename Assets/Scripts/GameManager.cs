using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string ChooseOrder;
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
}
