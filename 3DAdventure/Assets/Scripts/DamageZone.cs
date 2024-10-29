using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public float damagePerSecond = 5f; // 초당 체력 감소량

    private void OnTriggerStay(Collider other)
    {
        // 태그가 "Player"인지 확인
        if (other.CompareTag("Player"))
        {
            // 플레이어의 HealthManager에 접근하여 체력 감소
            HealthManager healthManager = other.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }
}
