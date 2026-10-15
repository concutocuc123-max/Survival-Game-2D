using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract class WeaponBase : MonoBehaviour
{
    public float attackRate = 1f; 
    public float attackRange = 8f;
    protected float nextAttackTime;

    protected virtual void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    protected abstract void Attack();

    // Hàm tiện ích tìm quái gần nhất
    protected Transform GetNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < shortestDistance && dist <= attackRange)
            {
                shortestDistance = dist;
                nearest = enemy;
            }
        }
        return nearest != null ? nearest.transform : null;
    }
}