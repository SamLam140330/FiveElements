using FiveElement.Id;
using FiveElement.Stage1;
using UnityEngine;

namespace FiveElement.Player
{
    public abstract class PlayerManager : MonoBehaviour
    {
        private float _moveSpeed;
        private Animator _animator;
        private Rigidbody2D _rigidBody2D;
        protected Vector2 movement;
        private readonly int _forward = Animator.StringToHash("Forward");
        private readonly int _backward = Animator.StringToHash("Backward");
        private readonly int _left = Animator.StringToHash("Left");
        private readonly int _right = Animator.StringToHash("Right");

        private void Awake()
        {
            _moveSpeed = 1.5f;
            _animator = GetComponent<Animator>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (StageManager.IsTipsShow)
            {
                CheckEscBtn();
            }
            if (StageManager.FindElementNum < 5 && StageManager.IsPause == false)
            {
                MovePlayer();
                MoveAudio();
                MoveAnimation();
            }
            else if (StageManager.IsPause)
            {
                _animator.SetBool(_forward, false);
                _animator.SetBool(_backward, false);
                _animator.SetBool(_left, false);
                _animator.SetBool(_right, false);
            }
        }

        private void FixedUpdate()
        {
            if (StageManager.FindElementNum < 5 && StageManager.IsPause == false)
            {
                _rigidBody2D.MovePosition(_rigidBody2D.position + _moveSpeed * Time.fixedDeltaTime * movement);
            }
        }

        private void CheckEscBtn()
        {
            if (StageManager.FindElementNum < 5 && StageManager.TimeLeft > 0)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    StageManager.PauseTheGame(StageManager.IsPause);
                }
            }
        }

        protected abstract void MovePlayer();

        private void MoveAudio()
        {
            if ((movement.x != 0 || movement.y != 0))
            {
                StageManager.MakeSomeAudio(AudioState.Play, 2);
            }
            else
            {
                StageManager.MakeSomeAudio(AudioState.Stop, 2);
            }
        }

        private void MoveAnimation()
        {
            if (movement.y < 0)
            {
                _animator.SetBool(_forward, true);
            }
            else
            {
                _animator.SetBool(_forward, false);
            }
            if (movement.y > 0)
            {
                _animator.SetBool(_backward, true);
            }
            else
            {
                _animator.SetBool(_backward, false);
            }
            if (movement.x < 0)
            {
                _animator.SetBool(_left, true);
            }
            else
            {
                _animator.SetBool(_left, false);
            }
            if (movement.x > 0)
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
