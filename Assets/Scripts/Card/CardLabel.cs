using TMPro;
using UnityEngine;

public class CardLabel: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;

    public void SetName(string text)
    {
        nameText.text = text;
    }
}
