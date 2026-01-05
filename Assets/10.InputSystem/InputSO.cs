using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _10.InputSystem
{
    [CreateAssetMenu(fileName = "InputSO", menuName = "SO/InputSO")]
    public class InputSo : ScriptableObject,InputSystem_Actions.IPlayerActions
    {
        public Vector2 MousePosUI { get; private set; }
        
        public Vector2 MousePosWorld
        {
            get
            {
                if(_mainCamera == null) _mainCamera = Camera.main;
                return _mainCamera.ScreenToWorldPoint(MousePosUI);
            }
        }

        public Vector3 MoveDir { get; private set; }
        public bool IsMove { get; private set; } = false;
        public Action jump;
        public bool IsJump { get; private set; } = false;

        public Action leftClickOn;
        public Action leftClickOff;
        public bool IsLeftClick { get; private set; } = false;
        public Action rightClick;
        public bool IsRightClick { get; private set; } = false;
        private InputSystem_Actions _controls;

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new InputSystem_Actions();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
            _mainCamera = Camera.main;
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveDir = context.ReadValue<Vector3>();
            IsMove = MoveDir != Vector3.zero;
        }
        
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                jump?.Invoke();
                IsJump = true;
            }

            if (context.canceled)
            {
                IsJump = false;
            }
        }
        
        private Camera _mainCamera;
        public void OnMouse(InputAction.CallbackContext context)
        {
            MousePosUI = context.ReadValue<Vector2>();
        }

        public void OnLeftClick(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                leftClickOn?.Invoke();
                IsLeftClick = true;
            }

            if (context.canceled)
            {
                leftClickOff?.Invoke();
                IsLeftClick = false;
            }
        }

        public void OnRightClick(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                rightClick?.Invoke();
                IsRightClick = true;
            }

            if (context.canceled)
            {
                IsRightClick = false;
            }
        }
        
    }
}
