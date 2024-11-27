using MonClick.Code.EnemyFabric;
using MonClick.Code.PlayerControl;
using MonClick.Code.PlayerInput;
using MonClick.Code.UI;
using UnityEngine;
using Zenject;

namespace MonClick.Code.GameServices
{
    public class GameplayInjector : MonoInstaller
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerBase _playerBase;
        [SerializeField] private GameUI _gameUI;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private GameController _gameController;
        [SerializeField] private DamageVisualizer _damageVisualizer;

        public override void InstallBindings()
        {
            var inputHandler = SelectInpuHandler();
            Container.Bind<InputHandler>().FromInstance(inputHandler);

            Container.Bind<Player>().FromInstance(_player);
            Container.Bind<PlayerBase>().FromInstance(_playerBase);
            Container.Bind<GameUI>().FromInstance(_gameUI);
            Container.Bind<EnemySpawner>().FromInstance(_enemySpawner);
            Container.Bind<GameController>().FromInstance(_gameController);
            Container.Bind<DamageVisualizer>().FromInstance(_damageVisualizer);
        }


        private InputHandler SelectInpuHandler()
        {
#if !UNITY_ANDROID
            var mouseInputHandler = new MouseInputHandler();
            return mouseInputHandler;
#else
            var inputHandler = new TouchInputHandler();
            return inputHandler;
#endif
        }
    }
}


