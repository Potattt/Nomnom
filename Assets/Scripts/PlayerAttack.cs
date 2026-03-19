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

    private bool isAttacking;

    private Shielding shieldScript;

    void Start()
    {
        shieldScript = GetComponent<Shielding>();
    }

    void Update()
    {
        if (shieldScript != null && shieldScript.IsShielding())
            return;

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
        isAttacking = true;

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

        // Reset attack state after short time
        Invoke(nameof(ResetAttack), 0.2f);
    }

    void ResetAttack()
    {
        isAttacking = false;
    }

    // 👇 used by Shield script
    public bool IsAttacking()
    {
        return isAttacking;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPos == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}