using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFA.TPS
{
    public class RagdollController : MonoBehaviour
    {

        private void Awake()
        {
            RBStatus(true);
            ColliderStatus(false);

        }

        public void RBStatus(bool status)
        {
            Rigidbody[] rg = GetComponentsInChildren<Rigidbody>();

            foreach (var rigidbody in rg)
            {
                rigidbody.isKinematic = status;
            }
        }

        public void ColliderStatus(bool status)
        {
            Collider[] cl = GetComponentsInChildren<Collider>();

            foreach (var collider in cl)
            {
                if (collider.CompareTag("Enemy")) continue;

                collider.enabled = status;
            }
        }
    }
}


