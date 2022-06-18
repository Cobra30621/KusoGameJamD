using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject teachingPanel;

    public void ShowTeachingPanel(){
        teachingPanel.SetActive(true);
    }

    public void StartGame(){
        SceneManager.LoadScene("Main");
    }
}
