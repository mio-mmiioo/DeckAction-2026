using TMPro;
using UnityEngine;

/// <summary>
/// デバッグ用のカード生成順確認するためのスクリプト
/// </summary>
public class CardLabel: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;

    public void SetName(string text)
    {
        nameText.text = text;
    }
}
