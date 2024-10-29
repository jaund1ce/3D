using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 30f;  // �����밡 ���� ���� ũ��

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� Rigidbody�� ������ �ִ��� Ȯ��
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // �������� ���� ĳ���Ϳ��� ���������� ����
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
