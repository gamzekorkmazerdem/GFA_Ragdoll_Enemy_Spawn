using GFA.TPS.Movement;
using System;
using System.Collections;
using UnityEngine;

namespace GFA.TPS.Mediators
{
    public class EnemyMediator : MonoBehaviour, IDamageable
    {
        [SerializeField] 
        private float _health;

        private RagdollController _ragdollController;
        private CharacterMovement _characterMovement;
        private CharacterController _characterController;
        private Animator _animator;

        private void Awake()
        {
            _ragdollController = GetComponent<RagdollController>();
            _characterMovement = GetComponent<CharacterMovement>();
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        public void ApplyDamage(float damage, GameObject causer = null)
        {
            Debug.Log("applydamage for enemy is ON");

            _health -= damage;

            if (_health <= 0)
            {
                Debug.Log("health <= 0 for enemy");

                StartCoroutine(DisableDelayed());
                _animator.enabled = false;
                _characterMovement.enabled = false;
                _characterController.enabled = false;

                _ragdollController.RBStatus(false);
                _ragdollController.ColliderStatus(true);
            }
        }


        private IEnumerator DisableDelayed()
        {
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
        }
    }
}
