using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InGamePlayerInput : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty InputActionProperty;

    private void Awake()
    {
        InputActionProperty.action.performed += OnPerformed;
    }

    private void OnPerformed(InputAction.CallbackContext context)
    {
        Debug.Log(context.valueType);
    }

}
