using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float offsetYPosition;

    private void Start()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        transform.SetParent(canvas.transform, false);
        gameObject.SetActive(false);
    }

    public void ChangeHealth(float maxHealth, float currentHealth)
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }

        healthBar.fillAmount = currentHealth / maxHealth;
        if(healthBar.fillAmount <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void MoveTo(Transform target)
    {
        transform.position = new Vector2(target.position.x, (target.position.y + target.localScale.y / 2) + offsetYPosition);
    }
}
