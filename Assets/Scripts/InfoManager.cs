using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public Text lab_info;
    public GameObject info_box;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string info;

    [ContextMenu("Test")]
    public void Test(){
        ShowInfo(info);
    }

    public void ShowInfo(string info){
        info_box.SetActive(true);
        lab_info.text = info;
        StopAllCoroutines();
        StartCoroutine(Show());
    }

    IEnumerator Show(){
        yield return new WaitForSeconds(duration);
        info_box.SetActive(false);
    }
}
