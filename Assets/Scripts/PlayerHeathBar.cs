using UnityEngine;
using UnityEngine.UI;

public class PlayerHeathBar : MonoBehaviour
{
    [SerializeField] private Text healthBarText;
    [SerializeField] private Image healthBar;

    public void SetStartHeath(float maxHealth)
    {
        ChangeHealth(maxHealth, maxHealth);
    }

    public void ChangeHealth(float maxHealth, float currentHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
        healthBarText.text = $"{currentHealth} / {maxHealth}";
    }
}
