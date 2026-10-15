using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Projectile : MonoBehaviour
{
    public float speed = 12f;
    public int damage = 10;
    
    private Transform target;
    private Vector2 targetPos;

    public void SetTarget(Transform t)
    {
        target = t;
        if (target != null)
        {
            targetPos = target.position;
            RotateTowardsTarget(targetPos);
        }
    }

    void Update()
    {
        if (target != null) 
        {
            targetPos = target.position; // Cập nhật vị trí quái liên tục
            RotateTowardsTarget(targetPos); // Xoay đầu đạn theo hướng mục tiêu
        }
        
        // Đạn bay tới mục tiêu
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Hủy đạn nếu tới nơi
        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    void RotateTowardsTarget(Vector2 destination)
    {
        // Tính hướng từ vị trí hiện tại đến đích
        Vector2 direction = (destination - (Vector2)transform.position).normalized;
        
        // Tính góc xoay bằng lượng giác (Atan2) cho không gian 2D
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // Áp dụng góc xoay cho đạn
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject); // Hủy đạn sau khi trúng
        }
    }
}