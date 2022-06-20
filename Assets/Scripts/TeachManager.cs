using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeachManager : MonoBehaviour
{
    public GameObject teachingPanel;
    public void ShowTeachingPanel(bool active){
        teachingPanel.SetActive(active);
    }
}
