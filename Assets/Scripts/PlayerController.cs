using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int maxHealth = 100;
    private int currentHealth;
    
    [Header("Settings")]
    public float damageCooldown = 1f; 
    private float lastDamageTime;     
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;

    public static PlayerController Instance; 

    void Awake() 
    { 
        Instance = this; 
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        lastDamageTime = -damageCooldown; 
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
        rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        // Kiểm tra xem đã qua thời gian hồi chiêu bất tử chưa
        if (Time.time < lastDamageTime + damageCooldown) 
        {
            return; 
        }

        // Cập nhật lại thời điểm dính đòn
        lastDamageTime = Time.time;
        
        currentHealth -= damage;
        Debug.Log("Máu còn: " + currentHealth);
        
        if (currentHealth <= 0) 
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