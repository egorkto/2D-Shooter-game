using UnityEngine;

[RequireComponent(typeof(Player), typeof(MoveLimitationByCamera))]
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private MoveLimitationByCamera moveLimitation;

    private CrossingDerection crossingDerection = CrossingDerection.None;

    private void OnEnable()
    {
        moveLimitation.CrossingLeftBorder += CrossingLeftBorder;
        moveLimitation.CrossingRightBorder += CrossingRightBorder;
        moveLimitation.CrossingNone += CrossingNone;
    }
    private void OnDisable()
    {
        moveLimitation.CrossingLeftBorder -= CrossingLeftBorder;
        moveLimitation.CrossingRightBorder -= CrossingRightBorder;
        moveLimitation.CrossingNone -= CrossingNone;
    }

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && crossingDerection != CrossingDerection.Left)
        {
            player.MoveLeft();
        }
        if (Input.GetKey(KeyCode.D) && crossingDerection != CrossingDerection.Right)
        {
            player.MoveRight();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            player.Jump();
        }
    }

    private void CrossingLeftBorder()
    {
        player.StopDerection(Player.MoveDerection.Left);
        crossingDerection = CrossingDerection.Left;
    }

    private void CrossingRightBorder()
    {
        player.StopDerection(Player.MoveDerection.Right);
        crossingDerection = CrossingDerection.Right;
    }

    private void CrossingNone()
    {
        crossingDerection = CrossingDerection.None;
    }

    enum CrossingDerection
    {
        Left,
        Right,
        None
    }
}
