using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    private List<Enemy> wave = new List<Enemy>();

    public void SpawnWave(float waveSize)
    {
        BuildWave(waveSize);
        StartCoroutine(SpawnCorutine());
    }

    private IEnumerator SpawnCorutine()
    {
        for (int i = 0; i < wave.Count; i++)
        {
            float randomTime = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomTime);
            Instantiate(wave[i], transform.position, Quaternion.identity);
        }
        ClearWave();
    }

    public void BuildWave(float waveSize)
    {
        int randomEnemy;
        for (var i = 0; i < waveSize; i++)
        {
            randomEnemy = UnityEngine.Random.Range(0, enemies.Length);
            wave.Add(enemies[randomEnemy]);
        }
    }

    public void ClearWave()
    {
        for (int i = 0; i < wave.Count; i++)
        {
            wave.RemoveAt(i);
        }
    }
}
