// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;

namespace Fungus
{

    [CommandInfo("Personal", 
                 "IsPlaying", 
                 "是否開始事件")]
    [AddComponentMenu("")]
    public class IsTalking : Command 
    {
        [SerializeField] private bool isPlaying;
        // [SerializeField] private bool setBlur = true;
        public override void OnEnter()
        {
            FlowChartManager.SetIsPlaying(isPlaying);
        }

        public override string GetSummary()
        {
            string info = isPlaying ? "開始事件" : "結束事件";

            // if(setBlur)
            //     info += ",開啟背景模糊" ;
            // else
            //     info += ",關閉背景模糊";
            
            return info;
        }

        public override Color GetButtonColor()
        {
            return new Color32(216, 228, 170, 255);
        }

    }
}