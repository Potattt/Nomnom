using UnityEngine;

public class Shielding : MonoBehaviour
{
    public float shieldTime = 3f;
    private float shieldTimer;

    public float shieldCooldown = 2f;
    private float lastShieldTime;

    public KeyCode shieldKey;

    private bool isShielding;

    private PlayerHealth health;
    private Animator animator;
    private PlayerAttack attackScript;

    void Start()
    {
        health = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        attackScript = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        // Activate shield (with cooldown + cannot shield while attacking)
        if (Input.GetKeyDown(shieldKey) &&
            !isShielding &&
            Time.time >= lastShieldTime + shieldCooldown &&
            !attackScript.IsAttacking())
        {
            ActivateShield();
        }

        // Countdown
        if (isShielding)
        {
            shieldTimer -= Time.deltaTime;

            if (shieldTimer <= 0)
            {
                DeactivateShield();
            }
        }
    }

    void ActivateShield()
    {
        isShielding = true;
        shieldTimer = shieldTime;
        lastShieldTime = Time.time;

        health.isInvincible = true;
        animator.SetBool("Shield", true);
    }

    void DeactivateShield()
    {
        isShielding = false;

        health.isInvincible = false;
        animator.SetBool("Shield", false);
    }

    // 👇 allow other scripts to check
    public bool IsShielding()
    {
        return isShielding;
    }
}