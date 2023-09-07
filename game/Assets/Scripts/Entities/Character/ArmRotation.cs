using UnityEngine;
using UnityEngine.Serialization;
using Vector2 = UnityEngine.Vector2;

namespace Entities
{
    public class ArmRotation : MonoBehaviour
    {
        private PlayerCharacterController _controller;
        [SerializeField] private Transform _armPivot;
        [SerializeField] private SpriteRenderer _characterRenderer;
        [SerializeField] private SpriteRenderer _armRenderer;

        private Vector2 _aim = Vector2.right;

        private void Awake()
        {
            _controller = GetComponent<PlayerCharacterController>();
        }

        private void Start()
        {
            _controller.LookEvent += Look;
        }

        private void Look(Vector2 aim)
        {
            _aim = aim;
            RotateArm();
        }

        private void RotateArm()
        {
            var degree = Mathf.Atan2(y: _aim.y, x: _aim.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.Euler(0,0,degree);
            _armRenderer.flipY = Mathf.Abs(degree) > 90f;
            _characterRenderer.flipX = _armRenderer.flipY;
            _armPivot.rotation = rotation;
        }
    }
}