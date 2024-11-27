using MonClick.Code.Enemies;
using MonClick.Code.HealthSystem;
using MonClick.Code.PlayerInput;
using System;
using UnityEngine;
using Zenject;

namespace MonClick.Code.PlayerControl
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private float _attackCooldown = 1.0f;
        private InputHandler _inputHandler;

        public event Action<IDamagable> EnemyAttackRequest;
        private DateTime _previousAttackTime;

        [Inject]
        private void Init(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            _inputHandler.OnEnemyClicked += EnemyClicked;
        }

        private void EnemyClicked(IDamagable enemy)
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


