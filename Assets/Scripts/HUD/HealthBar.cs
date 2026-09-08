using UnityEngine;
using UnityEngine.UI;
//Writen with the help of "Prime Knight" on YouTube
public class HealthBar : MonoBehaviour
{
    public Slider healthBarValue;
    [SerializeField] public PlayerHealth playerHealth;

    void Start()
    {
        healthBarValue.maxValue = playerHealth.maxHealth;
        healthBarValue.value = playerHealth.currentHealth;
    }

    public void UpdateHealthBar(int currentHealth)
    {
        healthBarValue.value = currentHealth;
    }
}
