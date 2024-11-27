using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonClick.Code.HealthSystem
{
    public class HealthControllerEnemy : HealthController
    {
        public override void ResetHealth()
        {
            _currentHealth = _maxHealth;
        }
    }
}

