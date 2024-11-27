using MonClick.Code.HealthSystem;
using UnityEngine;

namespace MonClick.Code.PlayerInput
{
    public class MouseInputHandler : InputHandler
    {
        public override void Handle()
        {
            var touchPos = Input.mousePosition;

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touchPos), Vector2.zero);

                if (hit.collider != null && hit.collider.tag != "PlayerBase")
                {
                    IDamagable enemy = hit.collider.gameObject.GetComponentInChildren<IDamagable>();
                    if (enemy != null)
                    {
                        SendEnemyClicked(enemy);
                    }
                }
            }
        }
    }
}

