using UnityEngine;

public class Bomb : BulletBase
{
    [SerializeField] private int damage;

    private void Update()
    {
        RaycastHit2D hit = CreateRay(-transform.up);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<Player>(out Player player))
            {
                player.GetDamage(damage);
            }
            Destroy(gameObject);
        }
        Movement(-Vector2.up);
    }
}
