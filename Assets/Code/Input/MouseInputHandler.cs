using MonClick.Code.Enemies;
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

                if (hit.collider != null)
                {
                    var enemy = hit.collider.gameObject.GetComponent<Enemy>();
                    if (enemy)
                    {
                        SendEnemyClicked(enemy);
                    }
                }
            }
        }
    }
}

