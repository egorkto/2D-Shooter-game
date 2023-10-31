using UnityEngine;

public class Bullet : BulletBase
{
    [SerializeField] private int damage;

    private void Update()
    {
        RaycastHit2D hit = CreateRay(transform.up);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.GetDamage(damage);
            }
            Destroy(gameObject);
        }
        Movement(Vector2.up);
    }

}
