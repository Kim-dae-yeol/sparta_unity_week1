using System;
using UnityEngine;

namespace Entities
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - player.transform.position ;
        }

        private void Update()
        {
            transform.position = (player.transform.position + _offset);
        }
    }
}