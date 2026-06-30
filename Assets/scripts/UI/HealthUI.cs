using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image healthBar;

    public float currentHealth = 100;
    public float maxHealth = 100;

    void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
