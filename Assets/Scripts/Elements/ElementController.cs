using UnityEngine;

namespace FiveElement.Elements
{
    public class ElementController : MonoBehaviour
    {
        private Rigidbody2D _rigidBody2D;

        private void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Walls"))
            {
                _rigidBody2D.velocity = Vector2.zero;
                _rigidBody2D.angularVelocity = 0;
            }
        }
    }
}
