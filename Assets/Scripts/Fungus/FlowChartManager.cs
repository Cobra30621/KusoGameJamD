using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowChartManager : MonoBehaviour
{
    public Flowchart m_flowchart;
    public string testBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    [ContextMenu("Test Block")]
    public void TestBlock(){
        PlayBlock(testBlock);
    }

    public void PlayBlock(string block){
        UseFungus.PlayBlock( m_flowchart ,block );
    }
}
