using UnityEngine;

namespace MonClick.Code.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected int _health;
        [SerializeField] protected float _attackValue;
        [SerializeField] protected float _normalSpeed;

        protected void Init(int health, float attackValue)
        {
            _health = health;
            _attackValue = attackValue;
        }

        public abstract void Go();
        public abstract void Attack();
        public abstract void Update();

    }

}
