using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
    public float speed = 2.5f;
    public int health = 30;
    public int damage = 10;
    
    [Header("Item Drop Prefabs")]
    public GameObject expPrefab;          
    public GameObject goldPrefab;        
    public GameObject upgradeStonePrefab; 

    private Transform player;

    void Start()
    {
        if (PlayerController.Instance != null)
            player = PlayerController.Instance.transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0) 
        {
            Die();
        }
    }

    void Die()
    {
        //  Luôn rơi Kinh nghiệm 
        if (expPrefab != null)
        {
            Instantiate(expPrefab, transform.position, Quaternion.identity);
        }

        //  Rơi Vàng 
        if (goldPrefab != null && Random.Range(0f, 100f) <= 50f)
        {
            // Tạo lệch vị trí một tí để không đè lên viên EXP
            Vector3 randomOffset = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0);
            Instantiate(goldPrefab, transform.position + randomOffset, Quaternion.identity);
        }

        //  Rơi Đá Nâng Cấp 
        if (upgradeStonePrefab != null && Random.Range(0f, 100f) <= 10f)
        {
            Vector3 randomOffset = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0);
            Instantiate(upgradeStonePrefab, transform.position + randomOffset, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}