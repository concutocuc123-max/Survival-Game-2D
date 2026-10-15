using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ItemType { Exp, Gold, UpgradeStone }

public class PickupItem : MonoBehaviour
{
    public ItemType itemType;
    public int value = 1;
    public float flySpeed = 8f;        
    public float magnetDistance = 4f; 

    private Transform playerTransform;

    void Start()
    {
        if (PlayerController.Instance != null)
            playerTransform = PlayerController.Instance.transform;
    }

    void Update()
    {
        if (playerTransform == null) return;

        // Tự động hút vào Player khi ở gần (Giống Vampire Survivors)
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        if (distance <= magnetDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, flySpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Cộng tài nguyên cho Player
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddItem(itemType, value);
            }

            Destroy(gameObject); 
        }
    }
}