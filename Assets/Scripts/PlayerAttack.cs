using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPos;
    public float attackRange = 0.6f;
    public int damage = 1;

    public float attackCooldown = 0.4f;
    private float lastAttackTime;

    public LayerMask playerLayers;

    public float knockbackForce = 8f;

    public KeyCode attackKey;

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (Input.GetKeyDown(attackKey))
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] playersHit = Physics2D.OverlapCircleAll(
            attackPos.position,
            attackRange,
            playerLayers
        );

        foreach (Collider2D player in playersHit)
        {
            if (player.gameObject == gameObject) continue;

            PlayerHealth health = player.GetComponent<PlayerHealth>();

            if (health != null)
            {
                Vector2 dir = (player.transform.position - transform.position).normalized;
                health.TakeDamage(damage, dir * knockbackForce);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPos == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}