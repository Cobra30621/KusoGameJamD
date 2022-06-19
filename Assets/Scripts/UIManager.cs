using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField]
    private GameObject fadeImageObj;
    [SerializeField]
    private Image loveBar;
    private Image fadeImage;
    private GameManager gameManager;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        fadeImage = fadeImageObj.GetComponent<Image>();
        fadeImage.gameObject.SetActive(false);
        gameManager = GameManager.instance;
        gameManager.OnEndValueChange += ReflashLoveBar;
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
        fadeImage.gameObject.SetActive(true);
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
        fadeImage.gameObject.SetActive(false);
        yield break;
    }

    public void ReflashLoveBar()
    {
        loveBar.fillAmount = (float)gameManager.FavorableEffect / (float)gameManager.NeedFavorableEffect;
    }
}
