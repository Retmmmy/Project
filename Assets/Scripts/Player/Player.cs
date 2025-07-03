using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Utilities;

public class Player : MonoBehaviour
{   
    public static Player Instance { get; private set; }

    [SerializeField] private float movingSpeed = 30f;

    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;



    private Rigidbody2D rb;
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        
    }

    


    private void FixedUpdate()
    {
        HandleMovement();

    }

    private void HandleMovement() {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();

        inputVector = inputVector.normalized;

        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y)> minMovingSpeed) {
            isRunning = true;
        } else {
            isRunning = false;
        }
    }
    public bool IsRunning() {
        return isRunning;
    }
    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;

    }

}
