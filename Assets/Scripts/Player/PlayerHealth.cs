using UnityEngine;

public class PlayerHealth : MonoBehaviour, Damageable
{
    public int currentHealth = 100;
    public int maxHealth = 100;
    public HealthBar healthBar;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.LogWarning("Player took damage! Health: " + currentHealth);
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.LogWarning("Player died!");
        //add death stuff
    }
}