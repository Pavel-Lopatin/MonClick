using MonClick.Code.Enemies;
using System;

namespace MonClick.Code.PlayerInput
{
    public abstract class InputHandler
    {
        public event Action<Enemy> OnEnemyClicked;
        public abstract void Handle();

        protected void SendEnemyClicked(Enemy enemy)
        {
            OnEnemyClicked?.Invoke(enemy);
        }
    }
}

