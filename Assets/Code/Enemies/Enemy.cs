using MonClick.Code.HealthSystem;
using System;
using UnityEngine;

namespace MonClick.Code.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected int _maxHealth;
        [SerializeField] protected int _attackValue;
        [SerializeField] protected float _normalSpeed;
        [SerializeField] protected HealthController _healthController;
        [SerializeField] private Collider2D _collider;

        private void Awake()
        {
            Init();
        }

        protected void Init()
        {
            _healthController.Init(_maxHealth);
            _healthController.OnDeath += Deactivate;
        }

        protected abstract void Go();
        protected abstract void Attack();
        protected abstract void Update();

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _healthController.ResetHealth();
            _collider.enabled = true;
            gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            _collider.enabled = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            IDamagable playerBase = collision.gameObject.GetComponent<IDamagable>();

            if (playerBase != null)
            {
                playerBase.GetDamage(_attackValue);
                _healthController.TryDeath();
            }
        }

        private void OnValidate()
        {
            if (_healthController == null) _healthController = GetComponent<HealthController>();
            if (_collider == null) _collider = GetComponent<Collider2D>();
        }
    }

}
