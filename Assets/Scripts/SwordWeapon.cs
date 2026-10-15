using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwordWeapon : WeaponBase
{
    public int swordDamage = 20;
    public float slashRadius = 2.5f; // Tầm chém xung quanh nhân vật

    protected override void Attack()
    {
        // Quét tất cả quái xung quanh Player
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, slashRadius);

        bool hitAny = false;
        foreach (Collider2D col in hitEnemies)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<Enemy>().TakeDamage(swordDamage);
                hitAny = true;
            }
        }

        if (hitAny)
        {
           Debug.Log("Kiếm chém quét quái vật!", this);
        }
    }

    // Hiển thị vòng tròn chém trong cửa sổ Scene để dễ căn chỉnh
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, slashRadius);
    }
}