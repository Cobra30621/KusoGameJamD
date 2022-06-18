using UnityEngine;
using Fungus;

public class UseFungus
{

    public static void PlayBlock(Flowchart fc, string targetBlock)
    {
        // var fc = GOwithFlowChart.GetComponent<Flowchart>();

        // 尋找Block
        Block tb = fc.FindBlock(targetBlock);
        // 當targetBlock有物件時執行Block
        if (tb != null)
        {
            fc.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + fc + "裡的 " + targetBlock + " Block");
        }
    }

}