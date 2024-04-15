using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    public Animator animator;
    public VectorValue pos;

    private Vector2 movement;

    private void Awake()
    {
        transform.position = pos.initialValue;
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMovement(InputAction.CallbackContext value)
    {   
        movement = value.ReadValue<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

            animator.SetBool("isWalking", true);
        } else
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void OnRun(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            animator.SetBool("isRunning", true);
            moveSpeed = 3f;
        }
        if (value.canceled)
        {
            animator.SetBool("isRunning", false);
            moveSpeed = 2f;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
   
}
