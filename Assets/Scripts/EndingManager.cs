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
    public GameObject closeEndButton;
    public Sound soundType;
    // Start is called before the first frame update
    void Start()
    {
        closeEndButton.SetActive(false);
        foreach (EndingData end in endings){
            // end.Init();
            string key = end.ending.ToString();
            end.finish = (PlayerPrefs.GetInt(key, 0)!=0);
        }
         CreateEndBars();
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


    public void CreateEndBars(){
        foreach (EndingData end in endings)
        {
            GameObject prefab = Instantiate(endBarPrefab, endPanelPos);
            EndBar endBar = prefab.GetComponent<EndBar>();

            endBar.Init(end, this);
            endBarList.Add(endBar);
        }
    }

    public void PlayEndingByEndBar(Ending ending){
        SetCurrentEnd(ending);
        ShowEndImage();
        ShowTwitter();
        PlayEndingSound();
        closeEndButton.SetActive(true);
    }

    public void CloseEnd(){
        foreach (EndingData end in endings){
            end.endObj.gameObject.SetActive(false);
        }

        closeEndButton.SetActive(false);
        SoundManager.Instance.Stop();
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

    public void ShowTwitter(){
        foreach (EndingData end in endings){
            if(end.ending == currrntEnding){
                end.twitterImage.SetActive(true);
                return;
            }
            
        }
        Debug.Log($"沒有結局{currrntEnding}");
    }

    

    public void PlayEndingSound(){
        bool hadEndSound = true;
        // 先用蠢一點的方式
        switch(currrntEnding){
            case Ending.SingEnd:
                soundType = Sound.SingEnd;
                break;
            case Ending.DirtyJokeEnd:
                soundType = Sound.DirtyJokeEnd;
                break;
            case Ending.GameEnd:
                soundType = Sound.GameEnd;
                break;
            case Ending.LoveFalseEnd:
                soundType = Sound.LoveFailEnd;
                break;
            case Ending.LoveSuccessEnd:
                soundType = Sound.LoveSuccessEnd;
                break;
            case Ending.WineEnd:
                soundType = Sound.WineEnd;
                break;
            case Ending.KusoEnd:
                soundType = Sound.KusoEnd;
                break;
            case Ending.LeaveEnd:
                soundType = Sound.LeaveEnd;
                break;
            case Ending.TakeSignEnd:
                soundType = Sound.TakeSignEnd;
                break;
            default:
                hadEndSound = false;
                break;
        }


        if(hadEndSound){
            SoundManager.Instance.Stop();
            SoundManager.Instance.PlayEndSound(soundType);
        }
            
    }

    
}

[System.Serializable]
public class EndingData{
    public Ending ending;
    public bool finish;
    public Sprite icon;
    public GameObject endObj;
    public GameObject twitterImage;

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


