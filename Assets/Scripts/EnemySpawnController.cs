using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnerPoints = new Transform[2];
    [SerializeField] private EnemySpawner spawner;
    [Range(0, 2)] [SerializeField] private int spawnersCount;
    [SerializeField] private float spawnTime;
    [SerializeField] private float waveSize;

    private EnemySpawner[] spawnerPool;
    private Timer timer;

    private void Start()
    {
        timer = new Timer();
        spawnerPool = new EnemySpawner[spawnersCount];
        for (int i = 0; i < spawnersCount; i++)
        {
            EnemySpawner currentSpawner = Instantiate(spawner, spawnerPoints[i].position, Quaternion.identity);
            spawnerPool[i] = currentSpawner;
        }
    }

    private void Update()
    {
        timer.TimerUpdate();
        if(timer.timeIsUp)
        {
            EnemySpawner selectedSpawner = spawnerPool[RandomSpawner()];
            selectedSpawner.SpawnWave(waveSize);
            timer.StartTimer(spawnTime);
        } 
    }

    private int RandomSpawner()
    {
        return Random.Range(0, spawnerPool.Length);
    }
}
