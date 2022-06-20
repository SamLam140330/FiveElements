using FiveElement.Id;
using UnityEngine;

namespace FiveElement.Doors
{
    public abstract class DoorManager : MonoBehaviour
    {
        [SerializeField] protected int currentState;
        [SerializeField] private Sprite[] doorState;
        private SpriteRenderer _spriteRenderer;
        protected delegate void ChangeDoor(DoorColor color);
        protected static event ChangeDoor OnChangeDoor;

        protected void OnChangeDoorState(DoorColor color)
        {
            OnChangeDoor?.Invoke(color);
        }

        protected virtual void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            OnChangeDoor += ChangeDoorState;
        }

        private void OnDisable()
        {
            OnChangeDoor -= ChangeDoorState;
        }

        protected virtual void ChangeDoorState(DoorColor color)
        {
            if (currentState == 0)
            {
                _spriteRenderer.sprite = doorState[1];
                currentState = 1;
            }
            else if (currentState == 1)
            {
                _spriteRenderer.sprite = doorState[0];
                currentState = 0;
            }
        }
    }
}
