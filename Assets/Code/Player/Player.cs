using MonClick.Code.Enemies;
using UnityEngine;
using Zenject;

namespace MonClick.Code.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInputController _playerInputController;

        // add visualizer

        private void Awake()
        {
            _playerInputController.EnemyAttackRequest += OnEnemyAttackRequest;
        }

        private void OnEnemyAttackRequest(Enemy enemy)
        {
            Attack(enemy);
        }

        private void Attack(Enemy enemy)
        {
            Destroy(enemy.gameObject);
        }

        private void OnValidate()
        {
            _playerInputController ??= gameObject.GetComponent<PlayerInputController>();
        }
    }
}
