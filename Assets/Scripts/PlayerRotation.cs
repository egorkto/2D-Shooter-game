using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Gun gun;

    private PlayerRotationDerection playerRotation;

    private void Start()
    {
        playerRotation = player.transform.localScale.x > 0 ? PlayerRotationDerection.Right : PlayerRotationDerection.Left;
    }

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (90 > rotationZ && rotationZ > -90)
        {
            if(playerRotation == PlayerRotationDerection.Left)
            {
                Flip(player.transform);
                playerRotation = PlayerRotationDerection.Right;
            }
        }

        else if (rotationZ > 90 || rotationZ < -90)
        {
            if (playerRotation == PlayerRotationDerection.Right)
            {
                Flip(player.transform);
                playerRotation = PlayerRotationDerection.Left;
            }
        }
        gun.RotateTo(rotationZ);
    }

    public void Flip(Transform target)
    {
        target.localScale = new Vector2(-target.localScale.x, target.localScale.y);
    }

    enum PlayerRotationDerection
    {
        Right,
        Left
    }
}
