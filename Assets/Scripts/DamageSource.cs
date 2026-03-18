using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private int minDamage = 1;
    [SerializeField] private int maxDamage = 3;
    [SerializeField] private float knockbackForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            // Direction from damage source → player
            Vector2 direction = (collision.transform.position - transform.position).normalized;

            // Random damage
            int damage = Random.Range(minDamage, maxDamage + 1);

            // Apply damage (your health script handles invincibility)
            playerHealth.TakeDamage(damage, direction * knockbackForce);
        }
    }
}