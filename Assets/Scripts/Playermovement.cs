using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 12f;
    public Animator animator;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    private Rigidbody2D rb;
    private bool isFacingRight = true;
private float attackPosStartX;
    public Transform attackPos;

    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;
    private bool isGrounded;

    void Start()
{
    rb = GetComponent<Rigidbody2D>();

    if (attackPos != null)
        attackPosStartX = attackPos.localPosition.x;
}

    void Update()
{
    isGrounded = Physics2D.OverlapCircle(
        groundCheck.position,
        groundCheckRadius,
        groundLayer
    );

    float move = 0;

    if (Input.GetKey(leftKey)) move = -1;
    if (Input.GetKey(rightKey)) move = 1;

    rb.velocity = new Vector2(move * speed, rb.velocity.y);

    // ✅ THIS FIXES YOUR ANIMATION
    animator.SetFloat("Speed", Mathf.Abs(move));

    if (Input.GetKeyDown(jumpKey) && isGrounded)
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    if (move > 0 && !isFacingRight) Flip();
    if (move < 0 && isFacingRight) Flip();
}

    void Flip()
{
    isFacingRight = !isFacingRight;

    Vector3 scale = transform.localScale;
    scale.x *= -1;
    transform.localScale = scale;
}

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}