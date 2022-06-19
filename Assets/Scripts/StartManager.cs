using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject teachingPanel;
    public List<GameObject> closeObj;
    public GameObject start_button; 
    public float duration;

    public void ShowTeachingPanel(){
        foreach (GameObject go in closeObj)
        {
            go.SetActive(false);
        }
        teachingPanel.SetActive(true);
        StartCoroutine(Show());
    }

    IEnumerator Show(){
        yield return new WaitForSeconds(duration);
        start_button.SetActive(true);
    }

    public void StartGame(){
        SceneManager.LoadScene("Main");
    }


}
