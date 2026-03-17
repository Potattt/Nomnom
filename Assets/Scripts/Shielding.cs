using UnityEngine;

public class Shielding : MonoBehaviour
{
    public float shieldTime = 3f;
    private float shieldTimer;

    public KeyCode shieldKey;

    private bool isShielding;

    private PlayerHealth health;
    private Animator animator;

    void Start()
    {
        health = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Activate shield
        if (Input.GetKeyDown(shieldKey) && !isShielding)
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

        health.isInvincible = true;
        animator.SetBool("Shield", true);
    }

    void DeactivateShield()
    {
        isShielding = false;

        health.isInvincible = false;
        animator.SetBool("Shield", false);
    }
}