using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameInput
{

    public enum MouseButton
    {
        Left, Right
    } 
    public class MouseUser : MonoBehaviour
    {
        private InputManager _inputManager;

        public Vector2 MousePosition { get; private set; }
        public Vector2 MouseInWorldPosition => Camera.main.ScreenToWorldPoint(MousePosition);

        private bool _isLeftMouseButtonPressed;
        private bool _isRightMouseButtonPressed;

        private void OnEnable()
        {
            _inputManager = InputManager.Instance;
            _inputManager.GameOther.MousePosition.performed += OnMousePositionPerformed;
            _inputManager.GameOther.PerformAction.performed += OnPerformActionPerformed;
            _inputManager.GameOther.PerformAction.canceled += OnPerformActionCanceled;
            _inputManager.GameOther.CancelAction.performed += OnCancelActionPerformed;
            _inputManager.GameOther.CancelAction.canceled += OnCancelActionCanceled;
        }

        private void OnDisable()
        {
            _inputManager.GameOther.MousePosition.performed -= OnMousePositionPerformed;
            _inputManager.GameOther.PerformAction.performed -= OnPerformActionPerformed;
            _inputManager.GameOther.PerformAction.canceled -= OnPerformActionCanceled;
            _inputManager.GameOther.CancelAction.performed -= OnCancelActionPerformed;
            _inputManager.GameOther.CancelAction.canceled -= OnCancelActionCanceled;
        }

        private void OnMousePositionPerformed(InputAction.CallbackContext ctx)
        {
            MousePosition = ctx.ReadValue<Vector2>();   
        }

        private void OnPerformActionPerformed(InputAction.CallbackContext ctx)
        {
            _isLeftMouseButtonPressed = true;
        }

        private void OnPerformActionCanceled(InputAction.CallbackContext ctx)
        {
            _isLeftMouseButtonPressed = false;
        }

        private void OnCancelActionPerformed(InputAction.CallbackContext ctx)
        {
            _isRightMouseButtonPressed = true;
        }

        private void OnCancelActionCanceled(InputAction.CallbackContext ctx)
        {
            _isRightMouseButtonPressed = false;
        }

        public bool IsMouseButtonPressed(MouseButton button)
        {
            return button == MouseButton.Left ? _isLeftMouseButtonPressed : _isRightMouseButtonPressed;
        }
    }
}