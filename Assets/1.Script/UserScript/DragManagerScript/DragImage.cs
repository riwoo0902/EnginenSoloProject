using System;
using _1.Script.EventBusScript;
using _1.Script.EventBusScript.Events;
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
            EventBus<Drag>.OnEvent += SetRectTransform;
        }
        
        private void SetRectTransform(Drag data)
        {
            _transform.position = data.pos;
            _transform.sizeDelta = data.size;
        }

        private void OnDestroy()
        {
            EventBus<Drag>.OnEvent -= SetRectTransform;
        }
        
    }
}