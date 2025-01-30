using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private short _moveValue = 0;
    [SerializeField]
    private MainController _mainController;
    [SerializeField]
    private string _onEnterSceneTarget;

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveValue = (short)context.ReadValue<Vector2>().x;
        _mainController?.SetControllerMovement(_moveValue);
    }

    public void OnEnter(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(enterRoutine());
        }
    }

    private IEnumerator enterRoutine()
    {
        SoundEffectManager.PlayEffect(SoundEffectKey.Enter);
        yield return new WaitForSeconds(1);
        SceneManager.OpenScene(_onEnterSceneTarget);
    }
}
