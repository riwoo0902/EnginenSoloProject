using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace _10.InputSystem
{
    [CreateAssetMenu(fileName = "Player Input", menuName = "SO/Core/PlayerInput", order = 5)]
    public class InputSO : ScriptableObject, InputSystem_Actions.IPlayerActions
    {
        private InputSystem_Actions _controls;

        private Camera _camera;
        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new InputSystem_Actions();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
            _camera = Camera.main;
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        public void SetCamara(Camera nowCamera) => _camera = nowCamera;
        
        
        public Vector2 mouseUIPosition;
        public Vector2 MouseWorldPosition => _camera.ScreenToWorldPoint(mouseUIPosition);
        public void OnMouse(InputAction.CallbackContext context)
        {
            mouseUIPosition = context.ReadValue<Vector2>();
        }

        
        public event Action OnMouseLeftPressed;
        public event Action OnMouseLeftReleased;
        public void OnLeftClick(InputAction.CallbackContext context)
        {
            if(context.performed)
                OnMouseLeftPressed?.Invoke();
            
            if(context.canceled)
               OnMouseLeftReleased?.Invoke();
                    
        }
        
        
        public event Action OnMouseRightPressed;
        public event Action OnMouseRightReleased;
        public void OnRightClick(InputAction.CallbackContext context)
        {
            if(context.performed)
                OnMouseRightPressed?.Invoke();
            
            if(context.canceled)
                OnMouseRightReleased?.Invoke();
        }

        
        public bool isAltPressed = false;
        public void OnAlt(InputAction.CallbackContext context)
        {
            isAltPressed = context.ReadValueAsButton();
        }

        
        public bool isShiftPressed = false;
        public void OnShift(InputAction.CallbackContext context)
        {
            isShiftPressed = context.ReadValueAsButton();
        }
        
        
        
    }
}