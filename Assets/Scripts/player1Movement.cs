using UnityEngine;

public class player1Movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isFacingRight = true;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        // Update animation
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
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
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}