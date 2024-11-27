using UnityEngine;

namespace MonClick.Code.HealthSystem
{
    public interface IDamagable 
    {
        Transform GetPosition();
        void GetDamage(int value);
    }
}

