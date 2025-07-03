using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputAction playerInputAction;
    private void Awake()
    {
        Instance = this;
        playerInputAction = new PlayerInputAction();
        playerInputAction.Enable();
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();

        return inputVector;
    }

   public Vector3 GetMousePosition() {
       Vector3 mousePos =   Mouse.current.position.ReadValue();
       return mousePos;
   }
}


