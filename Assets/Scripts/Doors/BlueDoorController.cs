using FiveElement.Id;
using UnityEngine;

namespace FiveElement.Doors
{
    public class BlueDoorController : DoorManager
    {
        private BoxCollider2D _boxCollider2D;

        protected override void Start()
        {
            base.Start();
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        protected override void ChangeDoorState(DoorColor color)
        {
            if (color == DoorColor.Blue)
            {
                base.ChangeDoorState(color);
                if (currentState == 0)
                {
                    _boxCollider2D.enabled = true;
                }
                else if (currentState == 1)
                {
                    _boxCollider2D.enabled = false;
                }
            }
        }
    }
}
