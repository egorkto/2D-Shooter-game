using UnityEngine;

public class EnemyShootBehaviour : IAttackble
{
    private BulletBase bullet;
    private Transform gunpoint;

    public EnemyShootBehaviour(BulletBase Bullet, Transform Gunpoint)
    {
        bullet = Bullet;
        gunpoint = Gunpoint;
    }

    public void Attack(float attackSpeed, Timer timer)
    {
        Object.Instantiate(bullet, gunpoint.position, Quaternion.identity);
        timer.StartTimer(attackSpeed);
    }
}
