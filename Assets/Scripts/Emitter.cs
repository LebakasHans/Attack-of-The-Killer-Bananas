using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public float spawnRadius = 5f;
    public int minEnemies = 3;
    public int maxEnemies = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    private void SpawnEnemies()
    {
        int numEnemies = Random.Range(minEnemies, maxEnemies + 1);

        for (int i = 0; i < numEnemies; i++)
        {
            float angle = Random.Range(0f, 360f);
            Vector2 spawnPosition = gameObject.transform.position + new Vector3(Mathf.Cos(angle) * spawnRadius, Mathf.Sin(angle) * spawnRadius, 0f);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
