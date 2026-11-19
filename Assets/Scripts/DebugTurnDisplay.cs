using TMPro;
using UnityEngine;

/// <summary>
/// 左上にターンを表示する
/// </summary>
public class DebugTurnDisplay : MonoBehaviour
{
    [Tooltip("DebugTrunTextを設定してください")]
    [SerializeField] private TextMeshProUGUI debugTurnText;

    public void SetTurnText(string turnMessage)
    {
        debugTurnText.text = turnMessage;
    }
}
