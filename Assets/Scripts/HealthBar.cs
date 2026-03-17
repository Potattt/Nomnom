using UnityEngine;

public class BurgerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("Sprites (Assign in Inspector)")]
    public Sprite[] burgerSprites; // drag your burger stages here

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateBurgerVisual();
    }

    void Update()
    {
        // TEST: press Space to take damage
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateBurgerVisual();

        if (currentHealth == 0)
        {
            Debug.Log("Burger fully eaten!");
        }
    }

    void UpdateBurgerVisual()
    {
        int index = maxHealth - currentHealth;

        if (index >= burgerSprites.Length)
            index = burgerSprites.Length - 1;

        spriteRenderer.sprite = burgerSprites[index];
    }
}