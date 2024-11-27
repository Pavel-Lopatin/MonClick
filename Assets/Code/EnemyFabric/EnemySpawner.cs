using MonClick.Code.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonClick.Code.EnemyFabric
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPoolController pool;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Enemy[] enemies;

        [SerializeField, Tooltip("Time in seconds btwn spawn")]
        private float spawnSpeed;
        [SerializeField] private int maxSpawnCount;
        [SerializeField] private List<Enemy> enemiesList;

        private IEnumerator spawnRoutine;

        private void Awake()
        {
            pool.Init();
            spawnRoutine = SpawnEnemiesCoroutine();
        }

        public void StartSpawnEnemies()
        {
            pool.DisableAllObjectsInPool();
            StartCoroutine(spawnRoutine);
        }

        public void StopSpawnEnemies()
        {
            StopCoroutine(spawnRoutine);
        }

        private IEnumerator SpawnEnemiesCoroutine()
        {
            int spawnCount = 0;

            while (spawnCount < maxSpawnCount)
            {
                spawnCount++;
                var enemy = enemies[Random.Range(0, enemies.Length)];
                var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                pool.CreateEnemy(spawnPoint);
                yield return new WaitForSeconds(spawnSpeed);
            }

        }

        private void OnValidate()
        {
            pool ??= pool = GetComponentInChildren<EnemyPoolController>();
        }
    }
}

