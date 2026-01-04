using _1.Script.EventBusScript;
using _1.Script.EventBusScript.Events;
using _10.InputSystem;
using Unity.Mathematics;
using UnityEngine;

namespace _1.Script.UserScript.DragManagerScript
{
    public class DragManager : MonoBehaviour
    {
        [SerializeField] private InputSo input;
        
        private bool _isDragging = false;
        
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

        private void Start()
        {
            EventBus<Drag>.Raise(new Drag(Vector2.zero, Vector2.zero));
        }

        private Vector2 _clickStartPoint;
        
        private void DragStart()
        {
            EventBus<Drag>.Raise(new Drag(Vector2.zero, Vector2.zero));
            _isDragging = true;
           _clickStartPoint = input.MousePosUI;
        }

        private void Draging()
        {
            Vector2 a = input.MousePosUI - _clickStartPoint;
            Vector2 b = _clickStartPoint + a * 0.5f;
            Vector2 c = math.abs(a);
            EventBus<Drag>.Raise(new Drag(b,c));
        }

        private void DragEnd()
        {
            EventBus<Drag>.Raise(new Drag(Vector2.zero, Vector2.zero));
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