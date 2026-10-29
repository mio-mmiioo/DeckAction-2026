using TMPro;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;
    [SerializeField] private TextMeshProUGUI nameText;

    private PlayerCombo combo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        combo = GetComponent<PlayerCombo>();
    }

    /// <summary>
    /// デバッグ用のプレイヤー
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            int i=cardManager.GetUseCard();
            if (i == 0) return;

            nameText.text = i.ToString();

        }


        nameText.text = combo.comboCount.ToString();


    }
}
