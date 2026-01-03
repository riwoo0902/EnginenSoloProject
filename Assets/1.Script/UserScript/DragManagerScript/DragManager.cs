using _1.Script.Lrw.MonoSingelton;
using _10.InputSystem;
using Unity.Mathematics;
using UnityEngine;

namespace _1.Script.UserScript.DragManagerScript
{
    public class DragManager : MonoSingleton<DragManager>
    {
        [SerializeField] private InputSo input;
        
        private DragImage _dragImage;
        
        protected override void Awake()
        {
            base.Awake();
            
            _dragImage = GetComponentInChildren<DragImage>();
            
            input.leftClickOn += DragStart;
            input.leftClickOff += DragEnd;
            
            
            
        }

        private Vector2 _clickStartPoint;
        
        private void DragStart()
        {
            _dragImage.gameObject.SetActive(true);
           _clickStartPoint = input.MousePosUI;
        }

        private void Draging()
        {
            Vector2 a = input.MousePosUI - _clickStartPoint;
            Vector2 b = _clickStartPoint + a * 0.5f;
            Vector2 c = math.abs(a);
            _dragImage.SetRectTransform(b,c);
            
            
        }

        private void DragEnd()
        {
            _dragImage.gameObject.SetActive(false);
            
        }

        private void Update()
        {
            if (input.IsLeftClick)
            {
                Draging();
            }
            
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            input.leftClickOn -= DragStart;
            input.leftClickOff -= DragEnd;
            
        }
    }
}