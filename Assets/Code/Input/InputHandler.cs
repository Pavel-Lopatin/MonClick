using MonClick.Code.Enemies;
using MonClick.Code.HealthSystem;
using System;

namespace MonClick.Code.PlayerInput
{
    public abstract class InputHandler
    {
        public event Action<IDamagable> OnEnemyClicked;
        public abstract void Handle();

        protected void SendEnemyClicked(IDamagable enemy)
        {
            OnEnemyClicked?.Invoke(enemy);
        }
    }
}

