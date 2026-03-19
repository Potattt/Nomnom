using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.F; // set per player in Inspector
    public float attackDuration = 0.2f;

    private bool isAttacking = false;
    private Collider2D hitbox;

    void Start()
    {
        hitbox = GetComponent<Collider2D>();
        hitbox.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            StartCoroutine(DoAttack());
        }
    }

    System.Collections.IEnumerator DoAttack()
    {
        isAttacking = true;
        hitbox.enabled = true;

        yield return new WaitForSeconds(attackDuration);

        hitbox.enabled = false;
        isAttacking = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject != transform.root.gameObject)
        {
            HealthManager health = other.GetComponent<HealthManager>();

            if (health != null)
            {
                health.TakeDamage(1);
            }
        }
    }
}


//asdflosdfp¨ls