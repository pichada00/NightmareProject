using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager11 : MonoBehaviour
{
    private static InputManager11 _instance;

    public static InputManager11 Instance
    {
        get { return _instance; }
    }

    private PlayercontrolTest inputActions;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        inputActions = new PlayercontrolTest();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
       inputActions.Disable();
    }
    public Vector2 GetPlayerMovement()
    {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }
    public Vector2 GetMouseDelta()
    {
        return inputActions.Player.Look.ReadValue<Vector2>();
    }

}
