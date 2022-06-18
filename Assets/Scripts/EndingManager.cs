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
        CloseAllEndImage();
    }

    public void GetEnd(Ending ending){
        foreach (EndingData end in endings){
            if(end.ending == ending){
                end.SetEnding();
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

    public void ShowEndImage(Ending ending){
        foreach (EndingData end in endings){
            if(end.ending == ending){
                if(end.endObj != null);
                    end.endObj.SetActive(true);
                return;
            }
            
        }
        Debug.Log($"沒有結局{ending}");
    }

    public void CloseAllEndImage(){
        foreach (EndingData end in endings){
            if(end.endObj != null)
                end.endObj.SetActive(false);
            
        }
    }
}

[System.Serializable]
public class EndingData{
    public Ending ending;
    public bool finish;
    public Sprite icon;
    public GameObject endObj;

    public void Init(){
        finish = false;
    }

    public void SetEnding(){

        finish = true;
    }
}

[System.Serializable]
public enum Ending{
    SingEnd , TakeSignEnd, DirtyJokeEnd, GameEnd,
    LoveSuccessEnd, LoveFalseEnd, KusoEnd, WineEnd, LeaveEnd
}


