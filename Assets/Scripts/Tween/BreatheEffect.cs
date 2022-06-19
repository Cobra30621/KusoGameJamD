using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BreatheEffect : MonoBehaviour
{
    public bool start = false;
    public bool loop = false;

    [SerializeField]
    private Text targetText;

    private Tween tween1,tween2;
    private Sequence sequence;
    // Start is called before the first frame update
    void Start()
    {
        targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, 0);

        tween2 = targetText.DOFade(1, 1).SetEase(Ease.InCubic);
        tween2.OnComplete(CheckRePlay);

        loop = true;
        //LoopAnimation();
    }

    public void LoopAnimation()
    {
        targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b,1);
        loop = true;
        start = true;
        tween1.Play();
    }

    private void CheckRePlay()
    {
        if (loop)
        {
            if(targetText.color.a == 0)
            {
                tween2 = targetText.DOFade(1, 1).SetEase(Ease.InCubic);
                tween2.OnComplete(CheckRePlay);
            }
            else
            {
                tween1 = targetText.DOFade(0, 1).SetEase(Ease.OutCubic);
                tween1.OnComplete(CheckRePlay);
            }
        }
        else
        {
            start = false;
        }
    }
}
