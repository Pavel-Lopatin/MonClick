
using MonClick.Code.HealthSystem;
using UnityEngine;

namespace MonClick.Code.PlayerInput
{
    public class TouchInputHandler : InputHandler
    {
        public override void Handle()
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero);

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
