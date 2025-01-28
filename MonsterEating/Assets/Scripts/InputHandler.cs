using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private short _moveValue = 0;
    [SerializeField]
    private MainController _mainController;

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveValue = (short)context.ReadValue<Vector2>().x;
        _mainController?.SetControllerMovement(_moveValue);
    }
}
