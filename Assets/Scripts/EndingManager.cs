using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    public List<EndingData> endings;
    public List<EndBar> endBarList;
    public GameObject endBarPrefab;
    public Transform endPanelPos;
    // Start is called before the first frame update
    void Start()
    {
        foreach (EndingData end in endings){
            end.Init();
        }
        UpdateIcons();
    }

    public void GetEnd(Ending ending){
        foreach (EndingData end in endings){
            if(end.ending == ending){
                end.GetEnding();
                Debug.Log($"取得結局{end.ending}");
                UpdateIcons();
                return;
            }
            
        }
        Debug.Log($"沒有結局{ending}");

        
    }

    [ContextMenu("UpdateIcons")]
    public void UpdateIcons(){
        DestoryAllEndBar();
        foreach (EndingData end in endings)
        {
            GameObject prefab = Instantiate(endBarPrefab, endPanelPos);
            EndBar endBar = prefab.GetComponent<EndBar>();

            endBar.SetIcon(end.finish, end.icon);
            endBarList.Add(endBar);
        }
    }

    private void DestoryAllEndBar(){
        foreach (EndBar bar in endBarList)
        {
            Destroy(bar.gameObject);
        }
        
        endBarList = new List<EndBar>();
    }

    // public bool WhetherGet(Ending ending){
    //     foreach (EndingData end in endings){
    //         if(end.ending == ending){
    //             return end.finish;
    //         }
    //     }
    //     Debug.Log($"沒有結局{ending}");
    //     return false;
    // }
}

[System.Serializable]
public class EndingData{
    public Ending ending;
    public bool finish;
    public Sprite icon;

    public void Init(){
        finish = false;
    }

    public void GetEnding(){

        finish = true;
    }
}

[System.Serializable]
public enum Ending{
    Sing , Late, LoveSuccess, LoveFalse, Kuso, Wine, Leave
}


