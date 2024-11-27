using UnityEngine;
using UnityEngine.UI;

namespace MonClick.Code.UI
{
    public abstract class DamageVisualizer : MonoBehaviour
    {
        [SerializeField] private Text _textPrefab;
        [SerializeField] private RectTransform _spawn;
        [SerializeField] private RectTransform _root;

        public void Visualize(string textVal, Vector3 spawnPosition)
        {
            var newText = GameObject.Instantiate(_textPrefab, _spawn.position, Quaternion.identity, _root);
            newText.text = textVal;
            newText.transform.position = spawnPosition;
            Fly(newText.gameObject);
        }

        protected abstract void Fly(GameObject flyingText);
    }
}