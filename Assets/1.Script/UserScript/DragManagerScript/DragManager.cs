using System;
using _1.Script.Lrw.MonoSingelton;
using _10.InputSystem;
using Unity.Mathematics;
using UnityEngine;

namespace _1.Script.UserScript.DragManagerScript
{
    public class DragManager : MonoSingleton<DragManager>
    {
        [SerializeField] private InputSo input;
        
        private bool _isDragging = false;
        public Action<DragData> Drag;
        protected override void Awake()
        {
            base.Awake();
            
            input.leftClickOn += DragStart;
            input.leftClickOff += DragEnd;
        }

        private Vector2 _clickStartPoint;
        
        private void DragStart()
        {
            Drag?.Invoke(new DragData(Vector2.zero,Vector2.zero));
            _isDragging = true;
           _clickStartPoint = input.MousePosUI;
        }

        private void Draging()
        {
            Vector2 a = input.MousePosUI - _clickStartPoint;
            Vector2 b = _clickStartPoint + a * 0.5f;
            Vector2 c = math.abs(a);
            Drag?.Invoke(new DragData(b,c));
            
        }

        private void DragEnd()
        {
            Drag?.Invoke(new DragData(Vector2.zero,Vector2.zero));
            _isDragging  = false;
        }

        private void Update()
        {
            if (_isDragging)
            {
                Draging();
            }
            
        }

        protected override void OnDestroy()
        {
            input.leftClickOn -= DragStart;
            input.leftClickOff -= DragEnd;
            base.OnDestroy();
        }
    }
}