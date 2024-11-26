
using UnityEngine;

namespace MonClick.Code.Enemies
{
    public class ToothEnemy : Enemy
    {
        protected override void Attack()
        {

        }

        protected override void Go()
        {

        }

        protected override void Update()
        {
            transform.Translate(Vector3.right * _normalSpeed * Time.deltaTime);

        }

    }

}
