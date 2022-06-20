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
    public Ending currrntEnding;
    // Start is called before the first frame update
    void Start()
    {
        foreach (EndingData end in endings){
            // end.Init();
            string key = end.ending.ToString();
            end.finish = (PlayerPrefs.GetInt(key, 0)!=0);
        }
        UpdateEndIcons();
    }

    public void GainEnd(Ending ending){
        foreach (EndingData end in endings){
            if(end.ending == ending){
                string key = end.ending.ToString();
                PlayerPrefs.SetInt(key, 1);
                Debug.Log($"取得結局{end.ending}");
                return;
            }
            
        }
        Debug.Log($"沒有結局{ending}");        
    }

    [ContextMenu("ResetSaveData")]
    public void ResetSaveData(){
        foreach (EndingData end in endings){
            string key = end.ending.ToString();
            PlayerPrefs.SetInt(key, 0);
        }
    }


    public void UpdateEndIcons(){
        foreach (EndingData end in endings)
        {
            GameObject prefab = Instantiate(endBarPrefab, endPanelPos);
            EndBar endBar = prefab.GetComponent<EndBar>();

            endBar.SetIcon(end.finish, end.icon);
            endBarList.Add(endBar);
        }
    }


    public void SetCurrentEnd(Ending ending){
        currrntEnding = ending;
    }

    public void ShowEndImage(){
        foreach (EndingData end in endings){
            if(end.ending == currrntEnding){
                end.endObj.SetActive(true);
                return;
            }
            
        }
        Debug.Log($"沒有結局{currrntEnding}");
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


