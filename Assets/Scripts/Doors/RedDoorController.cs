using FiveElement.Id;
using UnityEngine;

namespace FiveElement.Doors
{
    public class RedDoorController : DoorManager
    {
        private BoxCollider2D _boxCollider2D;

        protected override void Awake()
        {
            base.Awake();
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        protected override void ChangeDoorState(DoorColor color)
        {
            if (color == DoorColor.Red)
            {
                base.ChangeDoorState(color);
                if (doorState == DoorState.Close)
                {
                    _boxCollider2D.enabled = true;
                }
                else if (doorState == DoorState.Open)
                {
                    _boxCollider2D.enabled = false;
                }
            }
        }
    }
}
