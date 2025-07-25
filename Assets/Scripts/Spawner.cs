using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float enemyRate;
    public GameObject[] enemiesPrefab;
    public GameObject bossPrefab;
    float timer;
    int rounds = 0;

    public Transform player;

    public int spawnRadius = 10;

    private void OnEnable()
    {
        EventManager.PlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        EventManager.PlayerDeath -= OnPlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= enemyRate )
        {
            SpawnEnemy(randomizeEnemy());
            timer = 0;
            rounds++;
        }

        if(rounds == 20)
        {
            SpawnEnemy(bossPrefab);
            rounds = 0;
        }

        timer += Time.deltaTime;
    }

    void SpawnEnemy(GameObject enemyToSpawn)
    {
        // Generate random angle
        float angle = Random.Range(0f, 360f);
        // Convert angle to radians
        float radians = angle * Mathf.Deg2Rad;

        // Calculate spawn position
        float x = Mathf.Sin(radians) * spawnRadius;
        float z = Mathf.Cos(radians) * spawnRadius;
        Debug.Log(player.position);
        Vector3 spawnPosition = player.position + new Vector3(x, 5, z);

        // Instantiate the enemy
        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }

    public GameObject randomizeEnemy()
    {
        int length = enemiesPrefab.Length;
        int rng = Random.Range(0, 10);

        if (rng <= 7)
        {
            return enemiesPrefab[0];
        }
        else
        {
            return enemiesPrefab[1];
        }
    }

    private void OnPlayerDeath()
    {
        Destroy(gameObject);
    }
}
