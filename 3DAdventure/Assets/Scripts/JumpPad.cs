using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 30f;  // 점프대가 가할 힘의 크기

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 Rigidbody를 가지고 있는지 확인
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // 점프대의 힘을 캐릭터에게 순간적으로 가함
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
