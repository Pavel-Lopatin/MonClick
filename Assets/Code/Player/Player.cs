using MonClick.Code.Enemies;
using MonClick.Code.HealthSystem;
using MonClick.Code.UI;
using UnityEngine;
using Zenject;

namespace MonClick.Code.PlayerControl
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInputController _playerInputController;
        [SerializeField] private int _damage;

        // add visualizer
        [Inject] private DamageVisualizer _damageVisualizer;

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
            var damage = (-_damage).ToString();

            Vector3 screenPos = Camera.main.WorldToScreenPoint(enemy.GetPosition().position);

            _damageVisualizer.Visualize(damage.ToString(), screenPos);
            enemy.GetDamage(_damage);
        }

        private void OnValidate()
        {
            _playerInputController ??= gameObject.GetComponent<PlayerInputController>();
        }
    }
}
