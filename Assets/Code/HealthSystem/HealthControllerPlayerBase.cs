using UnityEngine;
using System;

namespace MonClick.Code.HealthSystem
{
    public class HealthControllerPlayerBase : HealthController
    {
        public override void ResetHealth()
        {
            _currentHealth = _maxHealth;
        }
    }

}
