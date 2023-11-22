using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputAdapter : Singleton<InputAdapter>
{
    public event System.Action<char> OnLetterPressed;
    public event System.Action OnSubmit;
    public event System.Action OnBackspace;

    public void KeyPress(InputAction.CallbackContext context)
    {
        if (context.performed && context.ReadValueAsButton())
        {
            char c = context.action.activeControl.displayName[0];
            if (context.action.activeControl.displayName == "Space")
            {
                c = ' ';
            }

            OnLetterPressed?.Invoke(c);
        }
    }

    public void Submit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnSubmit?.Invoke();
        }
    }

    public void Backspace(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnBackspace?.Invoke();
        }
    }
}
