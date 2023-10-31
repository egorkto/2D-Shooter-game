using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] private float speed = 500;
    [SerializeField] private float distance = 0;
    [SerializeField] private LayerMask solid;

    public void Movement(Vector2 derection)
    {
        transform.Translate(derection * speed * Time.deltaTime);
    }

    public RaycastHit2D CreateRay(Vector2 derection)
    {
        return Physics2D.Raycast(transform.position, derection, distance, solid);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
