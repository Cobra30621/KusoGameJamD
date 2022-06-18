using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField]
    private GameObject fadeImageObj;
    private Image fadeImage;
    void Start()
    {
        Instance = this;
        fadeImage = fadeImageObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeScene(float A, float time = 1)
    {
        StartCoroutine(fadeEnumerator(A, time));
    }
    IEnumerator fadeEnumerator(float A,float time)
    {
        Color color = Color.black;
        float startTime = Time.time;
        float startA = fadeImage.color.a;
        while(Time.time-startTime < time)
        {
            color.a = startA + (A-startA)*((Time.time - startTime)/time);
            fadeImage.color = color;
            yield return null;
        }
        color.a = A;
        fadeImage.color = color;
        yield break;
    }
}
