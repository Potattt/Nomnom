using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 6;
    private int currentHealth;
    public Sprite[] burgerSprites; // 6 or 7 sprites (your choice)
    public SpriteRenderer burgerRenderer; // drag Burger object here

    void Start()
    {
        currentHealth = maxHealth;
        UpdateBurgerVisual();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateBurgerVisual();

        if (currentHealth == 0)
        {
            Debug.Log(gameObject.name + " is dead");
        }
    }

    void UpdateBurgerVisual()
    {
        int index = maxHealth - currentHealth;

        if (index < 0)
            index = 0;

        if (index >= burgerSprites.Length)
            index = burgerSprites.Length - 1;

        burgerRenderer.sprite = burgerSprites[index];
    }
}