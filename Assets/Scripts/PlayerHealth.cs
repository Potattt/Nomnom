using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage, Vector2 knockback)
    {
        health -= damage;

        rb.velocity = Vector2.zero;
        rb.AddForce(knockback, ForceMode2D.Impulse);

        animator.SetTrigger("Hit");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 0.5f);
    }
}