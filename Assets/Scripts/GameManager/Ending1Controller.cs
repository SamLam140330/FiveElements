using FiveElement.Id;
using UnityEngine;

namespace FiveElement.GameManager
{
    public class Ending1Controller : StageManager
    {
        protected override void Awake()
        {
            base.Awake();
            LossStage = SceneStage.Opening;
            SceneStages = SceneStage.Ending1;
            Time.timeScale = 1f;
        }
    }
}
