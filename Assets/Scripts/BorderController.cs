using UnityEngine;

public class BorderController : MonoBehaviour
{
    public float screenWidth { get; private set; }
    public float screenHeight { get; private set; }
    public float cameraRightBorder { get; private set; }
    public float cameraLeftBorder { get; private set; }
    public float cameraBottomBorder { get; private set; }
    public float cameraTopBorder { get; private set; }
    public Vector3 freeSpace { get; private set; }

    [SerializeField] private new Camera camera;

    private Vector3 cameraLeftBottomAngle;
    private Vector3 cameraRightTopAngle;

    public void SetBorders()
    {
        cameraRightTopAngle = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, 0));
        cameraLeftBottomAngle = camera.ScreenToWorldPoint(new Vector3(0, 0, 0));

        screenWidth = cameraRightTopAngle.x - cameraLeftBottomAngle.x;
        screenHeight = cameraRightTopAngle.y - cameraLeftBottomAngle.y;

        cameraRightBorder = cameraRightTopAngle.x;
        cameraLeftBorder = cameraLeftBottomAngle.x;
        cameraTopBorder = cameraRightTopAngle.y;
        cameraBottomBorder = cameraLeftBottomAngle.y;
    }

    public void SetFreeSpace(Vector3 space)
    {
        freeSpace = space;
    }
}
