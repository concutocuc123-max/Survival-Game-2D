using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StaffWeapon : WeaponBase
{
    public GameObject magicOrbPrefab;

    protected override void Attack()
    {
        Transform target = GetNearestEnemy();
        if (target != null && magicOrbPrefab != null)
        {
            GameObject orb = Instantiate(magicOrbPrefab, transform.position, Quaternion.identity);
            Projectile proj = orb.GetComponent<Projectile>();
            if (proj != null)
            {
                proj.damage = 25; 
                proj.SetTarget(target);
            }
        }
    }
}