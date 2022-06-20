using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndBar : MonoBehaviour
{
    public Image image;
    public Image img_click;
    public EndingData endingData;
    public EndingManager em;
    
    public void Init(EndingData data, EndingManager endingManager){
        endingData = data;

        image.sprite = endingData.icon;
        image.gameObject.SetActive(endingData.finish);
        img_click.gameObject.SetActive(endingData.finish);

        em = endingManager;
    }


    public void PlayEnd(){
        Debug.Log("palyend");
        if(endingData.finish){
            em.PlayEndingByEndBar(endingData.ending);
            
        }
    }

}
