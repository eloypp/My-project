using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float jumpForce;
    public float speed;

    private Rigidbody2D rb;
    private Animator animator;
    private float horizontal;
    private float vertical;
    private bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");



        if (horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-5.0f, 5.0f, 5.0f);
        } else if (horizontal > 0.0f) 
        {
            transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
        }

        animator.SetBool("running", horizontal != 0.0f);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.9f))
        {
            grounded = true;
            
        } else 
        { 
            grounded = false;
           
        }

        if (Input.GetKeyDown(KeyCode.W) && grounded) 
        {
            Jump();
        
        }
        
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
}
