using MonClick.Code.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonClick.Code.EnemyFabric
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Enemy[] enemies;

        [SerializeField, Tooltip("Time in seconds btwn spawn")]
        private float spawnSpeed;
        [SerializeField] private int maxSpawnCount;
        [SerializeField] private List<Enemy> enemiesList;

        public void StartSpawnEnemies()
        {
            StartCoroutine(SpawnEnemies());
            Debug.Log("Start Spawn Enemies");
        }

        public void StopSpawnEnemies()
        {
            StopCoroutine(SpawnEnemies());
            Debug.Log("Finish Spawn Enemies");
        }

        private IEnumerator SpawnEnemies()
        {
            int spawnCount = 0;

            while (spawnCount < maxSpawnCount)
            {
                spawnCount++;
                var enemy = enemies[Random.Range(0, enemies.Length)];
                var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                Enemy newEnemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
                enemiesList.Add(newEnemy);

                yield return new WaitForSeconds(spawnSpeed);
            }

            Debug.Log("Finish Spawn Enemies");
        }
    }
}

