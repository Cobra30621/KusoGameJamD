using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WineManager : MonoBehaviour
{
    public float start_time = 30;
    public float timer; 

    public bool cleared; // a microgame is considered cleared if cleared = true
    public bool timeOver; // once set to true, the microgame will exit

    public GameObject winePanel; 
    public Text lab_time;
    // Start is called before the first frame update
    void Start()
    {
        cleared = false;
        timeOver = false;
        timer = start_time;
        winePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
    }

    void Countdown(){
        if(timeOver || cleared){return;}

        timer -= Time.deltaTime;
        if(timer < 0){
            timeOver = true;
            GameManager.instance.PlayEnding(EventType.WineEnd);
        }
        lab_time.text = "Time : " + Mathf.Ceil(timer);
    }

    public void Clear(){
        cleared = true;
        winePanel.SetActive(false);
    }
}
