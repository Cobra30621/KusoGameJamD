using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndBar : MonoBehaviour
{
    public Image image;
    
    public void SetIcon(bool getEnd, Sprite sprite){
        image.sprite = sprite;
        image.gameObject.SetActive(getEnd);
        
    }

}
