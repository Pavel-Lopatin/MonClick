using System;
using UnityEngine;

namespace MonClick.Code.HealthSystem
{
    public class HealthController : MonoBehaviour, IDamagable
    {
        private int _maxHealth;
        private int _currentHealth;

        public event Action OnDeath;
        public event Action<int> OnDamaged; 

        public void Init(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }

        public void GetDamage(int value)
        {
            CheckHealth(value);
        }

        public void TryDeath()
        {
            Death();
        }

        private void CheckHealth(int value)
        {
            if (value <= 0) return;

            _currentHealth = Mathf.Clamp(_currentHealth - value, 0, _maxHealth);
            OnDamaged?.Invoke(-value);

            if (_currentHealth <= 0) Death();
        }

        private void Death()
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}


