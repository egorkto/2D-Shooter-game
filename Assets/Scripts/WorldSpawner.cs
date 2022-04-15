using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField] private Transform ground;
    [SerializeField] private RectTransform informationContainer;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float uiPart;
    [SerializeField] float groundPart;
    [SerializeField] float groundSideOffset;

    private Vector2[] spawnPointsPosition = new Vector2[2];

    public void SpawnWorld(BorderController borderController)
    {
        if (spawnPoints.Length > 2)
        {
            Debug.LogError("Array length more 2!");
        }
        float leftBorder = borderController.cameraLeftBorder;
        float rightBorder = borderController.cameraRightBorder;
        float bottomBorder = borderController.cameraBottomBorder;
        float topBorder = borderController.cameraTopBorder;
        float screenHeight = borderController.screenHeight;
        float screenWidth = borderController.screenWidth;
        Vector3 worldCenter = new Vector3(0, 0, 0);

        float informationContainerYScale = screenHeight * uiPart;
        float informationContainerYPoisition = topBorder - (informationContainerYScale / 2);
        informationContainer.sizeDelta = new Vector2(screenWidth, informationContainerYScale);
        informationContainer.position = new Vector2(worldCenter.x, informationContainerYPoisition);

        float groundXScale = screenWidth + (groundSideOffset * 2);
        float groundYScale = screenHeight * groundPart;
        float groundYPoisition = bottomBorder + (transform.localScale.y / 2);
        ground.localScale = new Vector2(groundXScale, groundYScale);
        ground.position = new Vector2(worldCenter.x, groundYPoisition);

        borderController.SetFreeSpace(new Vector3(screenWidth, topBorder - informationContainer.sizeDelta.y, 0));

        float rightSpawnPointXPosition = rightBorder + groundSideOffset;
        float leftSpawnPointXPosition = leftBorder - groundSideOffset;
        float pointYPosition = bottomBorder + groundYScale;
        spawnPointsPosition[0] = new Vector2(rightSpawnPointXPosition, pointYPosition);
        spawnPointsPosition[1] = new Vector2(leftSpawnPointXPosition, pointYPosition);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i].position = spawnPointsPosition[i];
        }
    }
}
