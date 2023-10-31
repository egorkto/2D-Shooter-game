using UnityEngine;

public interface IAttackble
{
    public void Attack(float attackSpeed, Timer timer);
}

public interface IMoveble
{
    public void Move(float speed);
}