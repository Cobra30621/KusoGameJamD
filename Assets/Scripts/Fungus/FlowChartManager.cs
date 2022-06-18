using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowChartManager : MonoBehaviour
{
    public static FlowChartManager instance;
    public Flowchart m_flowchart;
    public string testBlock;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    [ContextMenu("Test Block")]
    public void TestBlock(){
        PlayBlock(testBlock);
    }

    public static void PlayEvent(string block){
        instance.PlayBlock(block);
    }

    public void PlayBlock(string block){
        UseFungus.PlayBlock( m_flowchart ,block );
    }
}
