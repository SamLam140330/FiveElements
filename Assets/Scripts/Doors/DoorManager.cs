using FiveElement.Id;
using UnityEngine;

namespace FiveElement.Doors
{
    public abstract class DoorManager : MonoBehaviour
    {
        [SerializeField] private DoorColor doorColor;
        [SerializeField] protected DoorState doorState;
        [SerializeField] private Sprite[] doorImage;
        private SpriteRenderer _spriteRenderer;

        protected delegate void ChangeDoor(DoorColor color);
        protected static event ChangeDoor OnChangeDoor;

        protected void OnChangeDoorState(DoorColor color)
        {
            OnChangeDoor?.Invoke(color);
        }

        protected virtual void Awake()
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
            if (doorState == DoorState.Close)
            {
                _spriteRenderer.sprite = doorImage[1];
                doorState = DoorState.Open;
            }
            else if (doorState == DoorState.Open)
            {
                _spriteRenderer.sprite = doorImage[0];
                doorState = DoorState.Close;
            }
        }
    }
}
