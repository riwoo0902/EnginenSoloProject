using System;
using UnityEngine;
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

        public void SetCamara(Camera nowCamera)
        {
            _camera = nowCamera;
        }

        public Vector2 MoveDirection { get; private set; }
        public void OnMove(InputAction.CallbackContext context)
        {
            MoveDirection = context.ReadValue<Vector2>();
        }
        
        public event Action OnJumpKeyPressed;
        public void OnJump(InputAction.CallbackContext context)
        {
            if(context.performed)
                OnJumpKeyPressed?.Invoke();
        }
        
        
        public Vector2 MouseUIPosition { get; private set; }
        public Vector2 MouseWorldPosition => _camera.ScreenToWorldPoint(MouseUIPosition);
        public void OnMouse(InputAction.CallbackContext context)
        {
            MouseUIPosition = context.ReadValue<Vector2>();
        }

        public event Action OnMouseLeftPressed;
        public void OnLeftClick(InputAction.CallbackContext context)
        {
            if(context.performed)
                OnMouseLeftPressed?.Invoke();
        }
        public event Action OnMouseRightPressed;
        public void OnRightClick(InputAction.CallbackContext context)
        {
            if(context.performed)
                OnMouseRightPressed?.Invoke();
        }
        
    }
}