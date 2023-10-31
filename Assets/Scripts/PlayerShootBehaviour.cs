using UnityEngine;

public class PlayerShootBehaviour : IAttackble
{
    private BulletBase bullet;
    private Transform gunpoint;

    public PlayerShootBehaviour(BulletBase Bullet, Transform Gunpoint)
    {
        bullet = Bullet;
        gunpoint = Gunpoint;
    }

    public void Attack(float attackSpeed, Timer timer)
    {
        if (Input.GetMouseButton(0))
        {
            Object.Instantiate(bullet, gunpoint.position, gunpoint.rotation);
            timer.StartTimer(attackSpeed);
        }
    }
}
