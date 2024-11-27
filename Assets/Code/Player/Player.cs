using MonClick.Code.Enemies;
using MonClick.Code.HealthSystem;
using UnityEngine;
using Zenject;

namespace MonClick.Code.PlayerControl
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInputController _playerInputController;
        [SerializeField] private int _damage;

        // add visualizer

        private void Awake()
        {
            _playerInputController.EnemyAttackRequest += OnEnemyAttackRequest;
        }

        private void OnEnemyAttackRequest(IDamagable enemy)
        {
            Attack(enemy);
        }

        private void Attack(IDamagable enemy)
        {
            enemy.GetDamage(_damage);
        }

        private void OnValidate()
        {
            _playerInputController ??= gameObject.GetComponent<PlayerInputController>();
        }
    }
}
