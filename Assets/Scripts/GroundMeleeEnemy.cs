using UnityEngine;

public class GroundMeleeEnemy : Enemy
{
    [SerializeField] private float damage;
    [SerializeField] private float hitDistance = 0.1f;
    [SerializeField] private Transform hitCollider;
    [SerializeField] private LayerMask playerLayer;

    private Player player;

    protected override void Initialization()
    {
        hitCollider.localScale = new Vector2(1 + hitDistance * 2, 1);
        Collider2D collider = hitCollider.GetComponent<BoxCollider2D>();
        player = FindObjectOfType<Player>();
        attackble = new MeleeAttackBehaviour(damage, player, playerLayer, collider);
        moveble = new ToPlayerMoveBehaviour(player, this);
    }
}
