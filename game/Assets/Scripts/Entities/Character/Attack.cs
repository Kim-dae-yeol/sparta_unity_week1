using System;
using UnityEngine;

namespace Entities
{
    public class Attack : MonoBehaviour
    {
        private PlayerCharacterController _controller;
        private GameObject _projectile;
        

        private void Awake()
        {
            _controller = GetComponent<PlayerCharacterController>();
        }

        private void Start()
        {
            _controller.ShootEvent += HandleAttack;
        }

        private void HandleAttack()
        {
            
        }

        private void DelayedAttack()
        {
            
        }
        
        
    }
}
