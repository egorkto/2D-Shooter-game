using System;
using UnityEngine;

public class MoveLimitationByCamera : MonoBehaviour
{
    public event Action CrossingLeftBorder;
    public event Action CrossingRightBorder;
    public event Action CrossingNone;

    private BorderController borderController;
    private float leftBorder;
    private float rightBorder;

    private void Start()
    {
        borderController = FindObjectOfType<BorderController>();
        leftBorder = borderController.cameraLeftBorder;
        rightBorder = borderController.cameraRightBorder;
    }

    private void FixedUpdate()
    {
        if (transform.position.x <= leftBorder)
        {
            CrossingLeftBorder?.Invoke();
        }
        else if (transform.position.x >= rightBorder)
        {
            CrossingRightBorder?.Invoke();
        }
        else
        {
            CrossingNone?.Invoke();
        }
    }
}
