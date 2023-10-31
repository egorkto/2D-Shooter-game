using UnityEngine;

public class FromSideToSideMoveBehaviour : IMoveble
{
    private Enemy enemy;
    private Vector2 rightPoint;
    private Vector2 leftPoint;
    private Vector2 activePoint;

    public FromSideToSideMoveBehaviour(Enemy Enemy, Vector2 RightPoint, Vector2 LeftPoint)
    {
        enemy = Enemy;
        rightPoint = RightPoint;
        leftPoint = LeftPoint;
    }

    public void Move(float speed)
    {
        if(enemy.transform.position.x >= rightPoint.x)
        {
            activePoint = leftPoint;
            enemy.LeftRotation();
        }
        if(enemy.transform.position.x <= leftPoint.x)
        {
            activePoint = rightPoint;
            enemy.RightRotation();
        }
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, activePoint, speed * Time.deltaTime);
    }
}
