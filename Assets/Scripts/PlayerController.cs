using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;
    
    [Header("Settings")]
    public float damageCooldown = 1f;
    private float lastDamageTime;

    public static PlayerController Instance; 

    void Awake() 
    { 
        Instance = this; 
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastDamageTime = -damageCooldown;

        // Đồng bộ máu ban đầu từ PlayerStats
        if (PlayerStats.Instance != null)
        {
            PlayerStats.Instance.currentHp = PlayerStats.Instance.GetTotalMaxHp();
        }
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (moveInput.x > 0) spriteRenderer.flipX = false;
        else if (moveInput.x < 0) spriteRenderer.flipX = true;
    }

    void FixedUpdate()
    {
        float moveSpeed = PlayerStats.Instance != null ? PlayerStats.Instance.GetTotalMoveSpeed() : 5f;
        rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        if (PlayerStats.Instance == null) return;

        if (Time.time < lastDamageTime + damageCooldown) 
        {
            return; 
        }

        lastDamageTime = Time.time;

        PlayerStats.Instance.currentHp -= damage;
        Debug.Log("Máu còn: " + PlayerStats.Instance.currentHp);
        
        if (PlayerStats.Instance.currentHp <= 0) 
        {
            Die();
        }
    }

    void Die() 
    { 
        Debug.Log("GAME OVER!"); 
        Time.timeScale = 0; 
    }
}