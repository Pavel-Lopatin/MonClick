using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonClick.Code.HealthSystem
{
    public class HealthControllerEnemy : HealthController
    {
        protected override void Death()
        {
            Debug.Log($"{gameObject.name} уничтожен!");
            Destroy(gameObject);
        }

        public override void ResetHealth()
        {
            
        }
    }
}

