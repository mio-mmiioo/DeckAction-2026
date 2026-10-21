using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CardData",menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    [Header("スプライト")] public Sprite image;
    [Header("カードID")] public int ID;
    [Header("カード名")] public string cardName;
    [Header("消費スタミナ")] public int stamina;
    [Header("ダメージ")] public int damage;
    [Header("出現率")] public float rate;

}
