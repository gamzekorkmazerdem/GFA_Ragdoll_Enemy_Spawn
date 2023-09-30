using GFA.TPS;
using GFA.TPS.Input;
using GFA.TPS.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFA.TPS.Mediators
{
    public class PlayerMediator : MonoBehaviour, IDamageable
    {
        private CharacterMovement _characterMovement;

        private GameInput _gameInput;

        private Camera _camera;

        private Plane _plane = new(Vector3.up, Vector3.zero);

        [SerializeField] 
        private float _health;


        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _gameInput = new GameInput();
            _camera = Camera.main;
        }

        private void Update()
        {
            HandleMovement();
        }

        private void OnEnable()
        {
            _gameInput.Enable();
        }

        private void OnDisable()
        {
            _gameInput.Disable();
        }


        private void HandleMovement()
        {
            var movementInput = _gameInput.Player.Movement.ReadValue<Vector2>();
            _characterMovement.MovementInput = movementInput;

            var ray = _camera.ScreenPointToRay(_gameInput.Player.PointerPosition.ReadValue<Vector2>());

            if (_plane.Raycast(ray, out float enter))
            {
                var worldPosition = ray.GetPoint(enter);
                var dir = (worldPosition - transform.position).normalized;
                var angle = -Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg + 90;
                _characterMovement.Rotation = angle;
            }
        }

        public void ApplyDamage(float damage, GameObject causer = null)
        {
            Debug.Log("applydamage for player");
            _health -= damage;
        }
    }

}
