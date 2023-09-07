using System;
using UnityEngine;

namespace Entities
{
    public class Movement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private PlayerCharacterController _controller;
        private Vector2 _movingDirection = Vector2.zero;

        private void Awake()
        {
            _controller = GetComponent<PlayerCharacterController>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _controller.MoveEvent += Move;
        }

        private void FixedUpdate()
        {
            ApplyMove();
        }

        private void Move(Vector2 dir)
        {
            _movingDirection = dir;
        }

        private void ApplyMove()
        {
            _rigidbody.velocity = _movingDirection * 5f;
        }
    }
}