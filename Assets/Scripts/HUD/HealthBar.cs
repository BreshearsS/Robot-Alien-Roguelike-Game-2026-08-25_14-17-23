using UnityEngine;
using UnityEngine.UI;
//Writen with the help of "Prime Knight" on YouTube
public class HealthBar : MonoBehaviour
{
    public Slider healthBarValue;
    public PlayerHealth playerHealth;

    void Start()
    {
        healthBarValue.maxValue = playerHealth.maxHealth;
        healthBarValue.value = playerHealth.currentHealth;
    }

    public void TakeDamage(int amount)
    {
        //healthBarValue.value -= amount;
        //healthBarValue.value = Mathf.Max(healthBarValue, 0); //Written by me but didn't work :(
        healthBarValue.value = Mathf.Clamp(healthBarValue.value - amount, 0, healthBarValue.maxValue); //Written by AI
    }
}
