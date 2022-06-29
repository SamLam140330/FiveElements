using FiveElement.Id;
using UnityEngine;

namespace FiveElement.GameManager
{
    public class Stage1Controller : StageManager
    {
        public delegate void CompleteElement(string color);
        public static event CompleteElement OnCompleteElement;

        protected override void Awake()
        {
            base.Awake();
            SceneStages = SceneStage.Stage1;
            FindElementNum = 0;
            TimeLeft = 400f;
            IsTipsShow = false;
            IsPause = true;
            Time.timeScale = 0f;
        }

        public static void GetAnElement(string color)
        {
            OnCompleteElement?.Invoke(color);
        }

        public static void CheckWinCond()
        {
            OnCheckingLevelComplete();
        }
    }
}
