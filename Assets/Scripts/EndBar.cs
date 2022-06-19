using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndBar : MonoBehaviour
{
    public Image image;
    public Image img_click;
    
    public void SetIcon(bool getEnd, Sprite sprite){
        image.sprite = sprite;
        image.gameObject.SetActive(getEnd);
        img_click.gameObject.SetActive(getEnd);
        
    }

}
