using System;
using _10.InputSystem;
using Unity.Mathematics;
using UnityEngine;

namespace _1.Script.UserScript.DragManagerScript
{
    public class DragManager : MonoBehaviour
    {
        [SerializeField] private InputSo input;
        
        private bool _isDragging = false;
        public Action<DragData> drag;
        
        public static DragManager Instance;
        protected void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            input.leftClickOn += DragStart;
            input.leftClickOff += DragEnd;
        }

        private Vector2 _clickStartPoint;
        
        private void DragStart()
        {
            drag?.Invoke(new DragData(Vector2.zero,Vector2.zero));
            _isDragging = true;
           _clickStartPoint = input.MousePosUI;
        }

        private void Draging()
        {
            Vector2 a = input.MousePosUI - _clickStartPoint;
            Vector2 b = _clickStartPoint + a * 0.5f;
            Vector2 c = math.abs(a);
            drag?.Invoke(new DragData(b,c));
            
        }

        private void DragEnd()
        {
            drag?.Invoke(new DragData(Vector2.zero,Vector2.zero));
            _isDragging  = false;
        }

        private void Update()
        {
            if (_isDragging)
            {
                Draging();
            }
            
        }

        private void OnDisable()
        {
            input.leftClickOn -= DragStart;
            input.leftClickOff -= DragEnd;
        }
        
    }
}