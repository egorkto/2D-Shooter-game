using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class Enemy : MonoBehaviour
{
    public static event EventHandler DestroyEnemy;
    public float Cost { get { return cost; } }

    protected IAttackble attackble;
    protected IMoveble moveble;

    [SerializeField] private float cost;
    [SerializeField] private float maxHealth;
    [SerializeField] protected float speed;
    [SerializeField] private float attackSpeed;
    [SerializeField] private EnemyHealthBar healthBar;

    private RotationDerection rotationDerection;
    private Timer timer;
    private EnemyHealthBar currentHealthBar;
    private float currentHealth;

    private void Start()
    {
        timer = new Timer();
        currentHealthBar = Instantiate(healthBar, transform.position, Quaternion.identity);
        currentHealth = maxHealth;
        rotationDerection = transform.localScale.x > 0 ? RotationDerection.Right : RotationDerection.Left;
        Initialization();
    }

    private void Update()
    {
        timer.TimerUpdate();
        moveble.Move(speed);
        if (timer.timeIsUp)
        {
            attackble.Attack(attackSpeed, timer);
        }
        currentHealthBar.MoveTo(transform);
    }

    protected abstract void Initialization();

    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        currentHealthBar.ChangeHealth(maxHealth, currentHealth);
        if(currentHealth <= 0)
        {
            DestroyEnemy?.Invoke(this, null);
            Destroy(gameObject);
        }
    }

    public void LeftRotation()
    {
        if (rotationDerection == RotationDerection.Right)
        {
            rotationDerection = RotationDerection.Left;
            Flip();
        }
    }

    public void RightRotation()
    {
        if (rotationDerection == RotationDerection.Left)
        {
            rotationDerection = RotationDerection.Right;
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    public enum RotationDerection
    {
        Right,
        Left
    }
}
