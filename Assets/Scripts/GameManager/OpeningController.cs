using FiveElement.Id;
using UnityEngine;

namespace FiveElement.GameManager
{
    public class OpeningController : StageManager
    {
        protected override void Awake()
        {
            base.Awake();
            SceneStages = SceneStage.Opening;
            Time.timeScale = 1f;
        }
    }
}
