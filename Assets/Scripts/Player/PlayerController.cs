using FiveElement.Id;
using FiveElement.Stage1;
using UnityEngine;

namespace FiveElement.Player
{
    public class PlayerController : MonoBehaviour
    {
        private float _moveSpeed;
        private Animator _animator;
        private Rigidbody2D _rigidBody2D;
        private Vector2 _movement;
        private readonly int _forward = Animator.StringToHash("Forward");
        private readonly int _backward = Animator.StringToHash("Backward");
        private readonly int _left = Animator.StringToHash("Left");
        private readonly int _right = Animator.StringToHash("Right");

        private void Start()
        {
            _moveSpeed = 1.5f;
            _animator = GetComponent<Animator>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Stage1Manager.FindElementNum < 5 && Stage1Manager.IsPause == false)
            {
                MovePlayer();
                MoveAudio();
                MoveAnimation();
            }
            else if (Stage1Manager.IsPause)
            {
                _animator.SetBool(_forward, false);
                _animator.SetBool(_backward, false);
                _animator.SetBool(_left, false);
                _animator.SetBool(_right, false);
            }
        }

        private void FixedUpdate()
        {
            if (Stage1Manager.FindElementNum < 5 && Stage1Manager.IsPause == false)
            {
                _rigidBody2D.MovePosition(_rigidBody2D.position + _moveSpeed * Time.fixedDeltaTime * _movement);
            }
        }

        private void MovePlayer()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
        }

        private void MoveAudio()
        {
            if ((_movement.x != 0 || _movement.y != 0))
            {
                Stage1Manager.MakeSomeAudio(AudioState.Play, 2);
            }
            else
            {
                Stage1Manager.MakeSomeAudio(AudioState.Stop, 2);
            }
        }

        private void MoveAnimation()
        {
            if (_movement.y < 0)
            {
                _animator.SetBool(_forward, true);
            }
            else
            {
                _animator.SetBool(_forward, false);
            }
            if (_movement.y > 0)
            {
                _animator.SetBool(_backward, true);
            }
            else
            {
                _animator.SetBool(_backward, false);
            }
            if (_movement.x < 0)
            {
                _animator.SetBool(_left, true);
            }
            else
            {
                _animator.SetBool(_left, false);
            }
            if (_movement.x > 0)
            {
                _animator.SetBool(_right, true);
            }
            else
            {
                _animator.SetBool(_right, false);
            }
        }
    }
}
