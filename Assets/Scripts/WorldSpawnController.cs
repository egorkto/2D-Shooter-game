using UnityEngine;

public class WorldSpawnController : MonoBehaviour
{
    [SerializeField] private BorderController borderController;
    [SerializeField] private WorldSpawner worldSpawner;

    private void Awake()
    {
        borderController.SetBorders();
        worldSpawner.SpawnWorld(borderController);
    }
}
