using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PlayerClass { Warrior, Archer, Mage }

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [Header("Class")]
    public PlayerClass characterClass = PlayerClass.Warrior;

    [Header("Tài sản")]
    public int gold = 10000; 

    [Header("Chỉ số gốc (Base Stats)")]
    public int baseAtk = 10;          
    public int baseMaxHp = 100;       
    public float baseAtkSpeed = 1f;   
    public float baseMoveSpeed = 5f;  

    [Header("Chỉ số từ Trang bị (Bonus Stats)")]
    public int bonusAtk = 0;
    public int bonusMaxHp = 0;
    public float bonusAtkSpeed = 0f;
    public float bonusMoveSpeed = 0f;

    [Header("Trạng thái hiện tại")]
    public int currentHp;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Khởi tạo máu hiện tại bằng tổng máu tối đa
        currentHp = GetTotalMaxHp();
    }

    // Các hàm tính tổng chỉ số 
    public int GetTotalAtk() => baseAtk + bonusAtk;
    public int GetTotalMaxHp() => baseMaxHp + bonusMaxHp;
    public float GetTotalAtkSpeed() => baseAtkSpeed + bonusAtkSpeed;
    public float GetTotalMoveSpeed() => baseMoveSpeed + bonusMoveSpeed;
}