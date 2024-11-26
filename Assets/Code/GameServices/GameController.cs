using MonClick.Code.EnemyFabric;
using MonClick.Code.PlayerControl;
using UnityEngine;
using Zenject;
using System;
using MonClick.Code.UI;

namespace MonClick.Code.GameServices
{
    public class GameController : MonoBehaviour
    {
        [Inject] private Player _player;
        [Inject] private PlayerBase _playerBase;
        [Inject] private EnemySpawner _spawner;
        [Inject] private GameUI _gameUI;

        public event Action OnGameStarted;
        public event Action OnPlayerBaseDestroyed;

        [Inject]
        private void Init()
        {
            _playerBase.OnBaseDestroyed += EndGame;
            _gameUI.OnStartButtonClicked += StartGame;
            _gameUI.ShowStartGamePanel(true);
        }

        private void StartGame()
        {
            _spawner.StartSpawnEnemies();
            OnGameStarted?.Invoke();
        }

        private void EndGame()
        {
            _spawner.StopSpawnEnemies();
            OnPlayerBaseDestroyed?.Invoke();
        }
    }
}


