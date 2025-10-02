using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private IControllable controllable;
    private GameActions gameAction;

    private void Awake()
    {
        gameAction = new GameActions();
        gameAction.Enable();

        controllable = GetComponent<IControllable>();
    }

    private void OnEnable()
    {
        gameAction.Gameplay.Jump.performed += OnJumpPerformed;
    }

    private void OnDisable()
    {
        gameAction.Gameplay.Jump.performed -= OnJumpPerformed;
    }
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        controllable.Jump();
    }
}
