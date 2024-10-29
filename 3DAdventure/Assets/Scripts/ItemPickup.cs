using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;  // ȹ���� Item ScriptableObject�� Inspector�� �Ҵ�

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ ��Ҵ��� Ȯ�� (�±� ��� ����)
        if (other.CompareTag("Player"))
        {
            Debug.Log("�浹 ����");
            // �÷��̾��� �κ��丮�� ������ �߰�
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.AddItem(item);
                Debug.Log($"{item.itemName}��(��) ȹ���߽��ϴ�!");
                Destroy(gameObject);  // ������ ������Ʈ �ı�
            }
        }
    }
}
