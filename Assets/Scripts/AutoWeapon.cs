using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoWeapon : MonoBehaviour
{
    public GameObject projectilePrefab; // Viên đạn
    public float fireRate = 1.5f;       // Tốc độ bắn (viên/giây)
    public float attackRange = 10f;     // Tầm đánh
    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootNearestEnemy();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void ShootNearestEnemy()
    {
        // Tìm tất cả quái vật trên bản đồ
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        // Tìm quái gần nhất
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= attackRange)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        // Bắn nếu có quái trong tầm
        if (nearestEnemy != null && projectilePrefab != null)
        {
            GameObject proj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            proj.GetComponent<Projectile>().SetTarget(nearestEnemy.transform);
        }
    }
}