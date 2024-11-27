using DG.Tweening;
using UnityEngine;

namespace MonClick.Code.UI
{
    public class DamageVisualizerVertical : DamageVisualizer
    {
        [SerializeField] private float _flyLength;
        [SerializeField] private float _flyTime;

        protected override void Fly(GameObject flyingText)
        {
            Vector3 endPos = flyingText.transform.position + new Vector3(0, _flyLength, 0);

            var tween = flyingText.transform.DOMove(endPos, _flyTime);
            

            tween.onComplete += () => Destroy(flyingText.gameObject);
        }
    }
}


