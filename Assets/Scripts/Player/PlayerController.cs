using UnityEngine;

namespace FiveElement.Player
{
    public class PlayerController : PlayerManager
    {
        [SerializeField] private bool allowHorizontalMove;
        [SerializeField] private bool allowVerticalMove;

        protected override void MovePlayer()
        {
            if (allowHorizontalMove)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
            }

            if (allowVerticalMove)
            {
                movement.y = Input.GetAxisRaw("Vertical");
            }
        }
    }
}
