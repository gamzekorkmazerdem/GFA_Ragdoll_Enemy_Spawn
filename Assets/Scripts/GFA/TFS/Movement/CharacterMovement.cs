using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFA.TPS.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MonoBehaviour
    {
        private CharacterController _characterController;

        public Vector2 MovementInput { get; set; }

        [SerializeField]
        private float _movementSpeed = 4;
        public float MovementSpeed
        {
            get => _movementSpeed;
            set => _movementSpeed = value;
        }

        public float Rotation { get; set; }

        public Vector3 Velocity => _characterController.velocity;


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            var movement = new Vector3(MovementInput.x, 0, MovementInput.y);
            transform.eulerAngles = new Vector3(0, Rotation);
            _characterController.SimpleMove(movement * _movementSpeed);
            MovementInput = Vector2.zero;
        }
    }
}


