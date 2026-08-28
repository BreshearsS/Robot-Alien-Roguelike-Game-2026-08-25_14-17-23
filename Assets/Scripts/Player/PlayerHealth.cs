using UnityEngine;

public class PlayerHealth : MonoBehaviour, Damageable
{
    public int currentHealth = 100;
    public int maxHealth = 100;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log("Player took damage! Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // TODO: add your death logic here (restart level, play animation, etc.)
    }
}