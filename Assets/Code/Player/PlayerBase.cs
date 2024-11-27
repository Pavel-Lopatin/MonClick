using MonClick.Code.HealthSystem;
using UnityEngine;
using System;

namespace MonClick.Code.PlayerControl
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField] protected int _maxHealth;
        [SerializeField] private HealthControllerPlayerBase _healthController;

        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected Collider2D _collider;

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

        public void DisableBase()
        {
            _collider.enabled = false;
            _spriteRenderer.enabled = false;
        }

        public void EnableBase()
        {
            _collider.enabled = true;
            _spriteRenderer.enabled = true;
            ResetBaseHealth();
        }

        public void BaseDestroyed()
        {
            DisableBase();
            OnBaseDestroyed?.Invoke();
        }

        private void ResetBaseHealth()
        {
            _healthController.ResetHealth();
        }

        private void OnValidate()
        {
            _healthController ??= _healthController = GetComponent<HealthControllerPlayerBase>();
            _spriteRenderer ??= _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider ??= _collider = GetComponent<Collider2D>();
        }
    }
}


