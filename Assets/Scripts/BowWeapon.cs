using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BowWeapon : WeaponBase
{
    public GameObject arrowPrefab;

    protected override void Attack()
    {
        Transform target = GetNearestEnemy();
        if (target != null && arrowPrefab != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            arrow.GetComponent<Projectile>().SetTarget(target);
        }
    }
}