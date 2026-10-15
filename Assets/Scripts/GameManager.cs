using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 15f; // Quái sinh ra cách xa Player
    public float spawnRate = 2f;    // Tốc độ sinh quái (con/giây)
    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnEnemy()
    {
        if (PlayerController.Instance == null || enemyPrefab == null) return;

        // Sinh quái ở vị trí ngẫu nhiên ngoài màn hình
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)PlayerController.Instance.transform.position + randomDir * spawnRadius;
        
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}