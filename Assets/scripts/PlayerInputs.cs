using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    #region variables
    public static event Action<Vector2> OnMove;
    public static event Action OnJump;
    private InputSystem_Actions inputs;
    #endregion
    private void Awake()
    {
        inputs = new InputSystem_Actions();
    }

    private void OnEnable()
    {

        inputs.Enable();

        inputs.Player.Move.performed += HandleMove;
        inputs.Player.Move.canceled += HandleMoveCanceled;
        inputs.Player.Jump.performed += HandleJump;
    }

    private void OnDisable()
    {
        inputs.Disable();

        inputs.Player.Move.performed -= HandleMove;
        inputs.Player.Move.canceled -= HandleMoveCanceled;
        inputs.Player.Jump.performed -= HandleJump;
    }

    private void HandleMove(InputAction.CallbackContext ctx) => OnMove?.Invoke(ctx.ReadValue<Vector2>());
    private void HandleMoveCanceled(InputAction.CallbackContext ctx) => OnMove?.Invoke(Vector2.zero);
    private void HandleJump(InputAction.CallbackContext context)
    {

        OnJump?.Invoke();
    }
}