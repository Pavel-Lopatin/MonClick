using MonClick.Code.Enemies;
using MonClick.Code.PlayerInput;
using System;
using UnityEngine;
using Zenject;

namespace MonClick.Code.Player
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private float _attackCooldown = 1.0f;
        private InputHandler _inputHandler;

        public event Action<Enemy> EnemyAttackRequest;
        private DateTime _previousAttackTime;

        [Inject]
        private void Init(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            _inputHandler.OnEnemyClicked += EnemyClicked;
        }

        private void EnemyClicked(Enemy enemy)
        {
            if (_previousAttackTime.AddSeconds(_attackCooldown) < DateTime.Now)
            {
                _previousAttackTime = DateTime.Now;
                EnemyAttackRequest?.Invoke(enemy);
            }
            else Debug.Log("Player attack reloading");
        }

        private void Update()
        {
            _inputHandler.Handle();
        }
    }
}


