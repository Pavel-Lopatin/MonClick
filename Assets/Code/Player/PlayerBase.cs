using MonClick.Code.HealthSystem;
using UnityEngine;
using System;

namespace MonClick.Code.PlayerControl
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField] protected int _maxHealth;
        [SerializeField] private HealthController _healthController;

        public event Action OnBaseDestroyed;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _healthController.Init(_maxHealth);
            _healthController.OnDeath += BaseDestroyed;
        }

        private void OnValidate()
        {
            if (_healthController == null) _healthController = GetComponent<HealthController>();
        }

        public void BaseDestroyed()
        {
            OnBaseDestroyed?.Invoke();
        }
    }
}


