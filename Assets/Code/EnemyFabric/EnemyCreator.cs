using MonClick.Code.Enemies;
using UnityEngine;

namespace MonClick.Code.EnemyFabric
{
    public abstract class EnemyCreator 
    {
        public abstract Enemy Create(Vector3 position, Quaternion rotation);
    }
}

