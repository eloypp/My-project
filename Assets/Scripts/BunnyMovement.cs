using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    private Animator animator;
    private Rigidbody2D rb;
    private float movementTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ResetMovementTimer();
    }

    void Update()
    {
        // Contar tiempo para moverse cada 5 segundos
        movementTimer -= Time.deltaTime;
        if (movementTimer <= 0)
        {
            MoveRandomDirection();
            ResetMovementTimer();
        }

        bool isMoving = Mathf.Abs(rb.velocity.x) > 0.1f;

        // Aplicar la variable isMoving a tu animaci�n
        animator.SetBool("Walking", isMoving);
    }

    void MoveRandomDirection()
    {
        // Cambiar la direcci�n del conejo (hacia adelante o hacia atr�s)
        float randomDirection = Random.Range(0.0f, 1.0f);
        if (randomDirection < 0.5f)
        {
            // Mover hacia adelante y girar hacia la derecha
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            // Mover hacia atr�s y girar hacia la izquierda
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void ResetMovementTimer()
    {
        // Establecer el temporizador a 5 segundos
        movementTimer = 5.0f;
    }
}
