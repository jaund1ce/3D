using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> inventory = new List<Item>();  // ������ ����Ʈ
    private Item currentItem;  // ���� ���õ� ������

    public StaminaManager staminaManager;
    public HealthManager healthManager;

    void Update()
    {
        // F Ű�� ���� ���� ������ ���
        if (Input.GetKeyDown(KeyCode.F) && currentItem != null)
        {
            UseItem(currentItem);
            inventory.Remove(currentItem);  // ��� �� �κ��丮���� ����
            currentItem = null;  // ������ ����
        }
    }

    // ������ �߰� �Լ�
    public void AddItem(Item item)
    {
        inventory.Add(item);
        currentItem = item;  // ���� ���� �������� ���� ���������� ����
        Debug.Log($"{item.itemName}�� �κ��丮�� �߰��Ǿ����ϴ�.");
    }

    // ������ ��� �Լ�
    private void UseItem(Item item)
    {
        if (item.isConsumable)
        {
            ApplyItemEffect(item);
            Debug.Log($"{item.itemName}�� ����߽��ϴ�: {item.description}");
        }
        else
        {
            Debug.Log($"{item.itemName}��(��) ��� �Ұ����� �������Դϴ�.");
        }
    }

    private void ApplyItemEffect(Item item)
    {
        // ������ ȿ�� ���� (��: ü�� ȸ��, ���ݷ� ���� ��)
        if (item.healthRestore > 0 && healthManager != null)
        {
            healthManager.Heal(item.healthRestore);
            Debug.Log($"ü���� {item.healthRestore}��ŭ ȸ���Ǿ����ϴ�.");
        }
        if (item.staminaRestore > 0 && staminaManager != null)
        {
            staminaManager.RestoreStamina(item.staminaRestore);
            Debug.Log($"���¹̳��� {item.staminaRestore}��ŭ ȸ���Ǿ����ϴ�.");
        }

        if (item.attackPower > 0)
        {
            Debug.Log($"���ݷ��� {item.attackPower}��ŭ �����߽��ϴ�.");
        }

        if (item.defensePower > 0)
        {
            Debug.Log($"������ {item.defensePower}��ŭ �����߽��ϴ�.");
        }
    }
}
