using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public string itemName;         // 아이템 이름
    public string description;      // 아이템 설명
    public Sprite icon;             // 아이템 아이콘 (UI에 표시할 때 사용)

    public int healthRestore;       // 체력 회복량
    public int attackPower;         // 공격력
    public int defensePower;        // 방어력
    public int staminaRestore;
    public bool isConsumable;       // 소비형 아이템인지 여부
}