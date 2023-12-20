using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float spawnRange = 5f;
    [SerializeField] private int maxEnemies = 10; // ћаксимальное количество врагов

    private float spawnTimer;
    private int spawnedEnemiesCount;

    private void Start()
    {
        spawnTimer = spawnInterval;
        spawnedEnemiesCount = 0;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f && spawnedEnemiesCount < maxEnemies)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        Vector2 randomSpawnPoint = (Vector2)transform.position + Random.insideUnitCircle * spawnRange;
        GameObject enemyClone = Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
        enemyClone.SetActive(true);

        // ”величиваем количество созданных врагов
        spawnedEnemiesCount++;
    }
}
