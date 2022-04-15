using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private BulletBase bullet;
    [SerializeField] private Transform gunpoint;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float offsetRotation;

    private IAttackble attackble;
    private Timer timer;

    private void Start()
    {
        attackble = new PlayerShootBehaviour(bullet, gunpoint);
        timer = new Timer();
    }

    private void Update()
    {
        timer.TimerUpdate();
        if(timer.timeIsUp)
        {
            attackble.Attack(attackSpeed, timer);
        }
    }

    public void RotateTo(float rotationZ)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offsetRotation);
    }
}
