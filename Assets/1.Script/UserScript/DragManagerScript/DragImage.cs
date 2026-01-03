using UnityEngine;

namespace _1.Script.UserScript.DragManagerScript
{
    [RequireComponent(typeof(RectTransform))]
    public class DragImage : MonoBehaviour
    {
        private RectTransform _transform;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }

        public void SetRectTransform(Vector2 position, Vector2 size)
        {
            _transform.position = position;
            _transform.sizeDelta = size;
        }
        
        
        
    }
}