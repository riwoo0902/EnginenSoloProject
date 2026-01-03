using System;
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

        private void Start()
        {
            DragManager.Instance.Drag += SetRectTransform;
        }

        private void SetRectTransform(DragData data)
        {
            _transform.position = data.pos;
            _transform.sizeDelta = data.size;
        }

        private void OnDestroy()
        {
            DragManager.Instance.Drag += SetRectTransform;
        }
    }
}