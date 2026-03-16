using UnityEngine;

public class Player1attack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPos;
    public float attackRange = 0.6f;
    public int damage = 1;

    public float attackCooldown = 0.4f;
    private float lastAttackTime;

    public LayerMask playerLayers;

    public float knockbackForce = 8f;

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] playersHit = Physics2D.OverlapCircleAll(attackPos.position, attackRange, playerLayers);

        foreach (Collider2D player in playersHit)
        {
            PlayerHealth target = player.GetComponent<PlayerHealth>();

            if (target != null)
            {
                Vector2 knockDir = (player.transform.position - transform.position).normalized;

                target.TakeDamage(damage, knockDir * knockbackForce);
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