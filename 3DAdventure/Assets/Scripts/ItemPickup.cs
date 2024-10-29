using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;  // 획득할 Item ScriptableObject를 Inspector에 할당

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 닿았는지 확인 (태그 사용 권장)
        if (other.CompareTag("Player"))
        {
            Debug.Log("충돌 감지");
            // 플레이어의 인벤토리에 아이템 추가
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.AddItem(item);
                Debug.Log($"{item.itemName}을(를) 획득했습니다!");
                Destroy(gameObject);  // 아이템 오브젝트 파괴
            }
        }
    }
}
