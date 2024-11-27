using UnityEngine;
using MonClick.Code.Pool;
using MonClick.Code.Enemies;

namespace MonClick.Code.EnemyFabric
{
    public class EnemyPoolController : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private int _poolCount;
        [SerializeField] private bool _autoExpand;


        private PoolMono<Enemy> enemyPool;

        public void Init()
        {
            enemyPool = new PoolMono<Enemy>(_enemyPrefab, _poolCount, _poolContainer);
        }

        public void CreateEnemy(Transform spawnPoint)
        {
            var newEnemy = enemyPool.GetFreeElement();
            newEnemy.transform.position = spawnPoint.position;

        }
    }
}

