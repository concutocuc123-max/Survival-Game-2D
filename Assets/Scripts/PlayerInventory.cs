using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerInventory : MonoBehaviour
{
    [Header("Tài nguyên hiện tại")]
    public int currentExp = 0;
    public int currentGold = 0;
    public int currentUpgradeStones = 0;

    public void AddItem(ItemType type, int amount)
    {
        switch (type)
        {
            case ItemType.Exp:
                currentExp += amount;
                Debug.Log($"Nhận {amount} EXP | Tổng: {currentExp}");
                break;
            case ItemType.Gold:
                currentGold += amount;
                Debug.Log($"Nhận {amount} Vàng | Tổng: {currentGold}");
                break;
            case ItemType.UpgradeStone:
                currentUpgradeStones += amount;
                Debug.Log($"Nhận {amount} Đá Nâng Cấp | Tổng: {currentUpgradeStones}");
                break;
        }
    }
}