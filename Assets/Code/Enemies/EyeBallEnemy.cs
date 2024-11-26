
using UnityEngine;

namespace MonClick.Code.Enemies
{
    public class EyeBallEnemy : Enemy
    {
        public override void Attack()
        {

        }

        public override void Go()
        {

        }

        public override void Update()
        {
            transform.Translate(Vector3.right * _normalSpeed * Time.deltaTime);

        }
    }

}
