using GFA.TPS.Mediators;
using UnityEngine;

namespace GFA.TPS
{
    public class PlayerDamage : MonoBehaviour
    {
        [SerializeField]
        private float damage;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter for PlayerDamage");

            if (other.TryGetComponent<EnemyMediator>(out var enemy))
            {
                Debug.Log("enemy-player trigger is ON");

                enemy.ApplyDamage(damage);
            }
        }
    }
}

