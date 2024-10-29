using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public string itemName;         // ������ �̸�
    public string description;      // ������ ����
    public Sprite icon;             // ������ ������ (UI�� ǥ���� �� ���)

    public int healthRestore;       // ü�� ȸ����
    public int attackPower;         // ���ݷ�
    public int defensePower;        // ����
    public int staminaRestore;      // ���׹̳� ȸ����
    public float speedIncreaseAmount;   // �ӵ� ������
    public float speedIncreaseDuration; // �ӵ� ���� ���� �ð�
    public bool isConsumable;       // �Һ��� ���������� ����
}