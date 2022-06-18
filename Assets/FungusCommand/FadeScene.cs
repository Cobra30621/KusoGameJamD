// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;

namespace Fungus
{

    [CommandInfo("Personal", 
                 "FaceScene", 
                 "是否開始事件")]
    [AddComponentMenu("")]
    public class FaceScene : Command 
    {
        [SerializeField] private float A;
        [SerializeField] private float duration = 1f;
        // [SerializeField] private bool setBlur = true;
        public override void OnEnter()
        {
            UIManager.Instance.FadeScene(A, duration);
        }

        public override string GetSummary()
        {
            string info = $"畫面{A}, 時間{duration}";

            // if(setBlur)
            //     info += ",開啟背景模糊" ;
            // else
            //     info += ",關閉背景模糊";
            
            return info;
        }

        public override Color GetButtonColor()
        {
            return new Color32(50, 228, 170, 255);
        }

    }
}