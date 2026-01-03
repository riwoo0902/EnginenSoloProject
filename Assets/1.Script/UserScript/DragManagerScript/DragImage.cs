using System;
using UnityEngine;

namespace _1.Script.UserScript.DragManagerScript
{
    [RequireComponent(typeof(RectTransform))]
    public class DragImage : MonoBehaviour
    {
        private RectTransform _transform;
        private DragManager _dragManager;
        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
            _dragManager = transform.root.GetComponent<DragManager>();
        }

        private void Start()
        {
            _dragManager.drag += SetRectTransform;
        }

        private void SetRectTransform(DragData data)
        {
            _transform.position = data.pos;
            _transform.sizeDelta = data.size;
        }

        private void OnDestroy()
        {
            _dragManager.drag -= SetRectTransform;
        }
        
    }
}