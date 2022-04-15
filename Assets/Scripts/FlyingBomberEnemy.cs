using UnityEngine;

public class FlyingBomberEnemy : Enemy
{
    [SerializeField] private BulletBase bullet;
    [SerializeField] private Transform gunpoint;
    [SerializeField] private float flyingHeightOffset;

    private BorderController borderController;
    private Vector2 leftBorder;
    private Vector2 rightBorder;
    private float topBorder;

    protected override void Initialization()
    {
        borderController = FindObjectOfType<BorderController>();

        topBorder = borderController.freeSpace.y;
        transform.position = new Vector3(transform.position.x, topBorder - flyingHeightOffset, 0);
        leftBorder = new Vector2(borderController.cameraLeftBorder, transform.position.y);
        rightBorder = new Vector2(borderController.cameraRightBorder, transform.position.y);

        attackble = new EnemyShootBehaviour(bullet, gunpoint);
        moveble = new FromSideToSideMoveBehaviour(this, rightBorder, leftBorder);
    }
}