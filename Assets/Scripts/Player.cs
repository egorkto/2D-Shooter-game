using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerHeathBar healthBar;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private float maxHealth;

    private new Rigidbody2D rigidbody;
    private MoveDerection moveDerection;
    private float currentHealth;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetStartHeath(maxHealth);
    }

    public void StopDerection(MoveDerection derection)
    {
        if (derection == moveDerection)
        {
            rigidbody.linearVelocity = new Vector2(0, rigidbody.linearVelocity.y);
        }
    }

    public void Jump()
    {
        if (rigidbody.linearVelocity.y == 0)
        {
            rigidbody.linearVelocity = Vector2.up * jumpForce * Time.deltaTime;
        }
    }

    public void Movement(float xDerection)
    {
        rigidbody.linearVelocity = new Vector2((xDerection * speed * Time.deltaTime), rigidbody.linearVelocity.y);
    }

    public virtual void GetDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.ChangeHealth(maxHealth, currentHealth);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void MoveRight()
    {
        if (moveDerection == MoveDerection.Left)
        {
            moveDerection = MoveDerection.Right;
        }
        Movement(Vector2.right.x);
    }

    public void MoveLeft()
    {
        if (moveDerection == MoveDerection.Right)
        {
            moveDerection = MoveDerection.Left;
        }
        Movement(-Vector2.right.x);
    }

    public enum MoveDerection
    {
        Right,
        Left,
    }
}
