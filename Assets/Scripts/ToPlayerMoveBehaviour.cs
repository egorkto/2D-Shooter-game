using UnityEngine;

public class ToPlayerMoveBehaviour : IMoveble
{
    private Player player;
    private Enemy enemy;

    public ToPlayerMoveBehaviour(Player Player, Enemy Enemy)
    {
        player = Player;
        enemy = Enemy;
    }

    public void Move(float speed)
    {
        if(player.transform.position.x > enemy.transform.position.x)
        {
            enemy.RightRotation();
        }
        else
        {
            enemy.LeftRotation();
        }
        Vector2 target = new Vector2(player.transform.position.x, enemy.transform.position.y);
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, target, speed * Time.deltaTime);
    }
}
