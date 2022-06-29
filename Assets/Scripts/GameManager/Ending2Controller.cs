using FiveElement.Id;
using UnityEngine;

namespace FiveElement.GameManager
{
    public class Ending2Controller : StageManager
    {
        protected override void Awake()
        {
            base.Awake();
            SceneStages = SceneStage.Ending2;
            Time.timeScale = 1f;
        }
    }
}
