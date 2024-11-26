using MonClick.Code.HealthSystem;
using UnityEngine;

namespace MonClick.Code.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected int _maxHealth;
        [SerializeField] protected int _attackValue;
        [SerializeField] protected float _normalSpeed;
        [SerializeField] protected HealthController _healthController;

        private void Awake()
        {
            Init();
        }

        protected void Init()
        {
            _healthController.Init(_maxHealth);
        }

        protected abstract void Go();
        protected abstract void Attack();
        protected abstract void Update();

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
        }
    }

}
