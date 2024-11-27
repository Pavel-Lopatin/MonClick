using MonClick.Code.Enemies;
using UnityEngine;

namespace MonClick.Code.EnemyFabric
{
    public class EyeBallCreator : EnemyCreator
    {
        public override Enemy Create(Vector3 position, Quaternion rotation)
        {
            var prefab = Resources.Load<GameObject>("Resources/EyeBallMonsterPrefab_T1");
            var go = GameObject.Instantiate(prefab, position, rotation);
            var enemyComponent = go.AddComponent<EyeBallEnemy>();
            return enemyComponent;
        }
    }
}