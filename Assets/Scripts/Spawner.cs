using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float enemyRate;
    public GameObject[] enemiesPrefab;
    float timer;

    public Transform player;

    public int spawnRadius = 10;

    // Update is called once per frame
    void Update()
    {
        if (timer >= enemyRate)
        {
            SpawnEnemy();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void SpawnEnemy()
    {
        // Generate random angle
        float angle = Random.Range(0f, 360f);
        // Convert angle to radians
        float radians = angle * Mathf.Deg2Rad;

        // Calculate spawn position
        float x = Mathf.Sin(radians) * spawnRadius;
        float y = Mathf.Cos(radians) * spawnRadius;
        Vector3 spawnPosition = player.position + new Vector3(x, y, 0);

        // Instantiate the enemy
        Instantiate(randomizeEnemy(), spawnPosition, Quaternion.identity);
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
}
