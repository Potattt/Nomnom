using UnityEngine;

public class player1Movement : MonoBehaviour
{
<<<<<<< HEAD
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
=======
    public float speed = 10f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isFacingRight = true;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movement input
        moveInput = Input.GetAxis("Horizontal");

        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Flip sprite
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Movement
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
>>>>>>> 447786c9ced28b55c3194085003c50ba0d3299f1
