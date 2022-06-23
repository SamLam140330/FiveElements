using FiveElement.Id;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FiveElement.Doors
{
    public class GreenButtonController : DoorManager
    {
        private Light2D _lighting;

        protected override void Awake()
        {
            base.Awake();
            _lighting = GetComponentInChildren<Light2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && doorState == 0)
            {
                OnChangeDoorState(DoorColor.Green);
            }
        }

        protected override void ChangeDoorState(DoorColor color)
        {
            if (color == DoorColor.Green)
            {
                base.ChangeDoorState(color);
                if (doorState == DoorState.Open)
                {
                    _lighting.enabled = true;
                }
                else if (doorState == DoorState.Close)
                {
                    _lighting.enabled = false;
                }
            }
        }
    }
}
