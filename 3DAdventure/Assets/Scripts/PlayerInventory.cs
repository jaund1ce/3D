using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> inventory = new List<Item>();  // 아이템 리스트
    private Item currentItem;  // 현재 선택된 아이템

    public StaminaManager staminaManager;
    public HealthManager healthManager;

    void Update()
    {
        // F 키를 눌러 현재 아이템 사용
        if (Input.GetKeyDown(KeyCode.F) && currentItem != null)
        {
            UseItem(currentItem);
            inventory.Remove(currentItem);  // 사용 후 인벤토리에서 제거
            currentItem = null;  // 아이템 비우기
        }
    }

    // 아이템 추가 함수
    public void AddItem(Item item)
    {
        inventory.Add(item);
        currentItem = item;  // 새로 얻은 아이템을 현재 아이템으로 설정
        Debug.Log($"{item.itemName}이 인벤토리에 추가되었습니다.");
    }

    // 아이템 사용 함수
    private void UseItem(Item item)
    {
        if (item.isConsumable)
        {
            ApplyItemEffect(item);
            Debug.Log($"{item.itemName}을 사용했습니다: {item.description}");
        }
        else
        {
            Debug.Log($"{item.itemName}은(는) 사용 불가능한 아이템입니다.");
        }
    }

    private void ApplyItemEffect(Item item)
    {
        // 아이템 효과 적용 (예: 체력 회복, 공격력 증가 등)
        if (item.healthRestore > 0 && healthManager != null)
        {
            healthManager.Heal(item.healthRestore);
            Debug.Log($"체력이 {item.healthRestore}만큼 회복되었습니다.");
        }
        if (item.staminaRestore > 0 && staminaManager != null)
        {
            staminaManager.RestoreStamina(item.staminaRestore);
            Debug.Log($"스태미나가 {item.staminaRestore}만큼 회복되었습니다.");
        }

        if (item.attackPower > 0)
        {
            Debug.Log($"공격력이 {item.attackPower}만큼 증가했습니다.");
        }

        if (item.defensePower > 0)
        {
            Debug.Log($"방어력이 {item.defensePower}만큼 증가했습니다.");
        }
    }
}
