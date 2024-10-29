using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public float damagePerSecond = 5f; // �ʴ� ü�� ���ҷ�

    private void OnTriggerStay(Collider other)
    {
        // �±װ� "Player"���� Ȯ��
        if (other.CompareTag("Player"))
        {
            // �÷��̾��� HealthManager�� �����Ͽ� ü�� ����
            HealthManager healthManager = other.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }
}
