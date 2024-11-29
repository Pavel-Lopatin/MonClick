using UnityEngine;
using MonClick.Code.Pool;
using MonClick.Code.Enemies;
using System.Collections.Generic;

namespace MonClick.Code.EnemyFabric
{
    public class EnemyPoolController : MonoBehaviour
    {
        [SerializeField] private Enemy _eyeBallMonster;
        [SerializeField] private Enemy _trashMonster;
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private int _poolCount;
        [SerializeField] private bool _autoExpand;

        private List<PoolMono<Enemy>> _enemyPools;
        private PoolMono<Enemy> _eyeBallPool;
        private PoolMono<Enemy> _trashPool;

        public int PoolsCount => _enemyPools.Count;

        public void Init()
        {
            _eyeBallPool = new PoolMono<Enemy>(_eyeBallMonster, _poolCount, _poolContainer);
            _eyeBallPool._autoExpand = this._autoExpand;

            _trashPool = new PoolMono<Enemy>(_trashMonster, _poolCount, _poolContainer);
            _trashPool._autoExpand = this._autoExpand;
        }

        public void CreateEyeBallEnemy(Transform spawnPoint)
        {
            var newEnemy = _eyeBallPool.GetFreeElement();
            newEnemy.transform.position = spawnPoint.position;

        }

        public void CreateTrashEnemy(Transform spawnPoint)
        {
            var newEnemy = _trashPool.GetFreeElement();
            newEnemy.transform.position = spawnPoint.position;

        }

        public void DisableAllObjectsInPool()
        {
            foreach (var pool in _enemyPools)
            {
                pool.DisableAllElements();
            }
        }
    }
}

