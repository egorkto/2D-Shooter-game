using System;
using UnityEngine;

public class MeleeAttackBehaviour : IAttackble
{
    private float damage;
    private LayerMask playerLayer;
    private Player player;
    private Collider2D hitCollider;

    public MeleeAttackBehaviour(float Damage, Player Player, LayerMask PlayerLayer, Collider2D HitCollider)
    {
        damage = Damage;
        player = Player;
        playerLayer = PlayerLayer;
        hitCollider = HitCollider;
    }

    public void Attack(float attackSpeed, Timer timer)
    {
        if (hitCollider.IsTouchingLayers(playerLayer))
        {
            player.GetDamage(damage);
            timer.StartTimer(attackSpeed);
        }
    }
}
